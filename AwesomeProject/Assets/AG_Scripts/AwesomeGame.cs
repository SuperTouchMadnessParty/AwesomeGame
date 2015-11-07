using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class AwesomeGame : MonoBehaviour 
{
	public GameObject shapeToClick;
	public List<GameObject> spawnObjects = new List<GameObject>();
	public List<Material> mats = new List<Material> ();
	public float shapeChangeDelay = 50;
	public GameObject incorrectExplosion;
	public GameObject ScoreGUIText;
	public GameObject redFlash;
	public GameObject redShape;
	public GameObject blueShape;
	public GameObject yellowShape;
	public GameObject greenShape;
	public GameObject textInfo;
	public GameObject trigger;
	public float speedMod;
    private GameObject lastShape;

    public List<GameObject> activeShapes = new List<GameObject>();




	protected float spawnDelay = 1.25f;

	public float SpawnDelay 
	{
		get
		{
			return Math.Abs(spawnDelay - SpeedModifier * 0.225f);
		}
	}

	public float SpeedModifier
	{
		get
		{
			return (score / 1000 ) * 0.2f;
		}
	}

	private int score = 0;
	private int checkscore = 0;
	private bool bIsPaused = true;

	public bool IsPaused
	{
		get{ return bIsPaused; }
	}

	private bool startingNextRound = false;
	private bool tutorial = true;
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
		// Speed mod testing
		speedMod = this.SpeedModifier;


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

		if ( tutorial ) 
		{
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					bIsPaused = false;
					DestroyObject(textInfo); 
					tutorial = false;
				}
			}
				else if(Input.GetMouseButtonDown(0))
				{
					bIsPaused = false;
					DestroyObject(textInfo); 
					tutorial = false; 
				}
		}

		if( !bIsPaused )
		{
			changeTime += Time.deltaTime;
            UpdateProgressBar(changeTime, false);
			if( changeTime >= shapeChangeDelay )
			{
                UpdateProgressBar(changeTime, true);
                ChangeShape();
				startingNextRound = true;
				changeTime = 0;
			}
		}

		if( startingNextRound )
		{
			// Deletes all shapes on screen when round changes
			/*
			GameObject[] ObjectsToDestroy = GameObject.FindGameObjectsWithTag("Shape");
			
			foreach(GameObject DestroyObject in ObjectsToDestroy)
			{
				Destroy(DestroyObject);
			}
			*/

			//changeTime += Time.deltaTime;
			if ( changeTime >= 3/SpeedModifier) // makes the immunity after shape change shorter as game progresses
				{
				startingNextRound = false;
				}
		}
	}

    void UpdateProgressBar(float changeTime, bool resetBar)
    {
        GameObject g = GameObject.FindGameObjectWithTag("ProgressBar");
        g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y - 0.035f);

        if(resetBar)
        {
            g.transform.position = new Vector3(g.transform.position.x, 0.0f);
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

				if(shape.gameObject.GetComponent<Renderer>().sharedMaterial.name == shapeToClick.gameObject.GetComponent<Renderer>().sharedMaterial.name) 
				{
					//Debug.Log ("YOU DID IT CHAMP!");
					healthMeter.RestoreHealth();
					score += (int)healthMeter.health;
					checkscore += (int)healthMeter.health;
					ScoreGUIText.GetComponent<GUIText>().text = score.ToString();
					SpawnExplosion( shape.explosionEffect, shape.transform.position, shape.transform.rotation );
				}
				else
				{
					healthMeter.TakeDamage();
					SpawnExplosion( incorrectExplosion, shape.transform.position, shape.transform.rotation );
					redFlash.GetComponent<ParticleSystem>().Emit(1);
				}
                activeShapes.RemoveAll(p => p.GetComponent<Shape>().id == shape.id);
                Destroy(hit.transform.gameObject);
			}
		}
	}

	public void ShapeFellOutOfBounds( Shape shape )
	{
		if( shape.gameObject.GetComponent<Renderer>().sharedMaterial.name == shapeToClick.GetComponent<Renderer>().sharedMaterial.name )
		{
			if (!startingNextRound)
			{
			healthMeter.TakeDamage();
			redFlash.GetComponent<ParticleSystem>().Emit(1);
			}
		}
	}

	void ChangeShape()
	{
		int i = UnityEngine.Random.Range (0, mats.Count);
		GameObject particleSystem;

		shapeToClick.GetComponent<Renderer>().material = mats [i];

		switch (i) {
			case 0:
				//particleSystem = 
				Instantiate (redShape);
                lastShape = redShape;
				break;
			case 1:
				Instantiate (yellowShape);
                lastShape = yellowShape;
                break;
			case 2:
				Instantiate (greenShape);
                lastShape = greenShape;
                break;
			case 3:
				Instantiate (blueShape);
                lastShape = blueShape;
                break;
		}

        // Logic to turn on/off particles

        foreach (GameObject g in activeShapes)
        {
            if(g.GetComponent<Renderer>().sharedMaterial.name == shapeToClick.GetComponent<Renderer>().sharedMaterial.name)
            {
                g.GetComponent<Shape>().ToggleHighlight(true);
            }
            else
            {
                g.GetComponent<Shape>().ToggleHighlight(false);
            }
        }


	}

	/*
	void OnTriggerEnter2D (Collider2D other)
	{
		DestroyAllObject("Shape");
	}

	void DestroyAllObject (string tag)
	{
		GameObject[] ObjectsToDestroy = GameObject.FindGameObjectsWithTag("Shape");
		
		foreach(GameObject DestroyObject in ObjectsToDestroy)
		{
			Destroy(DestroyObject);
		}
		startingNextRound = false;
	}
	*/
	public void SpawnExplosion( GameObject particleEffect, Vector3 position, Quaternion rotation )
	{
		GameObject firework = (GameObject)Instantiate( particleEffect, position, rotation );

		// Removing particles after they've played
		Destroy (firework, 1.5f);
	}

	public void GameOver()
	{
		bIsPaused = true;
	}
}

