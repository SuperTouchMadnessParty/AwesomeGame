using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AwesomeGame : MonoBehaviour 
{
	public GameObject shapeToClick;
	public ShapeSpawner sSpawner; 
	public List<GameObject> spawnObjects = new List<GameObject>();
	public List<Material> mats = new List<Material> ();
	public float shapeChangeDelay = 5;
	public GameObject incorrectExplosion;
	public GameObject ScoreGUIText;
	public GameObject redFlash;
	public GameObject redShape;
	public GameObject blueShape;
	public GameObject yellowShape;
	public GameObject greenShape;


	protected float spawnDelay = 1;

	public float SpawnDelay
	{
		get
		{
			return spawnDelay - SpeedModifier * 0.25f;
		}
	}

	public float SpeedModifier
	{
		get
		{
			return (float)( score / 1000 ) * 0.1f;
		}
	}

	private int score = 0;
	private bool bIsPaused = false;

	public bool IsPaused
	{
		get{ return bIsPaused; }

	}

	private bool startingNextRound = false;
	private int round;
	private float changeTime = 0;
	private HealthMeter healthMeter;
	private RuntimePlatform platform = Application.platform;

	// Use this for initialization
	void Start () 
	{
		if( platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer )
			Camera.main.aspect = 0.619f;

		ScoreGUIText.transform.position = Camera.main.WorldToViewportPoint( ScoreGUIText.transform.position );
		GameObject meter = GameObject.FindGameObjectWithTag( "HealthMeter" );
		healthMeter = meter.GetComponent< HealthMeter >();
		shapeToClick = GameObject.Find ("ShapeToClick");
		ChangeShape();

	}
	
	// Update is called once per frame
	void Update () 
	{
		// Mobile controls
		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) 
		{
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					checkTouch(Input.GetTouch(0).position);
				}
			}
		} 

		// Windows controls
		else if(platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor)
		{
			if(Input.GetMouseButtonDown(0))
			{
				checkTouch(Input.mousePosition); 
			}
		}

		if( !bIsPaused )
		{
			changeTime += Time.deltaTime;
			if( changeTime >= shapeChangeDelay )
			{
				//sSpawner.RoundChange();  *object reference not set to an instance of an object* error
				ChangeShape();
				changeTime = 0;
			}
		}

		if( startingNextRound )
		{

		}
	}

	void checkTouch(Vector2 position) 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if( !bIsPaused )
		{
			if (Physics.Raycast ( ray, out hit, Mathf.Infinity, 5 ) && hit.transform.gameObject.tag == "Shape" ) 
			{
				Shape shape = hit.transform.gameObject.GetComponent< Shape >();
				//Debug.Log (shape.name);

				if(shape.gameObject.renderer.material.name == shapeToClick.gameObject.renderer.material.name) 
				{
					Debug.Log ("YOU DID IT CHAMP!");
					healthMeter.RestoreHealth();
					score += (int)healthMeter.health;
					ScoreGUIText.GetComponent<GUIText>().text = score.ToString();
					SpawnExplosion( shape.explosionEffect, shape.transform.position, shape.transform.rotation );
				}
				else
				{
					healthMeter.TakeDamage();
					SpawnExplosion( incorrectExplosion, shape.transform.position, shape.transform.rotation );
					redFlash.particleSystem.Emit(1);
				}

				Destroy(hit.transform.gameObject);
			}
		}
	}

	public void ShapeFellOutOfBounds( Shape shape )
	{
		if( shape.gameObject.renderer.material.name == shapeToClick.renderer.material.name )
		{
			healthMeter.TakeDamage();
			redFlash.particleSystem.Emit(1);
		}
	}

	void ChangeShape()
	{
		int i = Random.Range (0, mats.Count);

		shapeToClick.renderer.material = mats [i];
		Instantiate (redShape);
		Instantiate (blueShape);
		Instantiate (yellowShape);
		Instantiate (greenShape);

	}

	public void SpawnExplosion( GameObject particleEffect, Vector3 position, Quaternion rotation )
	{
		Instantiate( particleEffect, position, rotation );
	}

	public void GameOver()
	{
		bIsPaused = true;
	}
}

