using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShapeSpawner : MonoBehaviour 
{
	public AwesomeGame game;
	public Vector3 direction = new Vector3( 0.0f, -1.0f, 0.0f );
	public float shapeInitialVelocity = 1.75f;
	public bool pauseSpawning = false;
	public int spawnGroup = 0;
	public float spawnTimer = 0;

	// Use this for initialization
	void Start () 
	{
		Spawn();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( !game.IsPaused && !pauseSpawning )
		{
			spawnTimer += Time.deltaTime;
			if( spawnTimer >= game.SpawnDelay )
			{
				Spawn();
				spawnTimer = 0;
			}
		}
	}

	public void Spawn() 
	{
		int i = Random.Range (0, game.spawnObjects.Count);
		//int j = Random.Range (0, colors.Length);
		GameObject shapeObject = (GameObject)Instantiate (game.spawnObjects [i], transform.position, game.spawnObjects[i].transform.rotation);
		Shape shapeComponent = shapeObject.GetComponent<Shape>();

		shapeComponent.SetDirection( direction );
		shapeComponent.SetVelocity( shapeInitialVelocity + game.SpeedModifier );
	}
}
