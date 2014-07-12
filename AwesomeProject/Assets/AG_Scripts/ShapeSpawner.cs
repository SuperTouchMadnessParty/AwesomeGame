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

	// Use this for initialization
	void Start () 
	{
		Invoke ("Spawn", game.spawnDelay);
	}
	
	// Update is called once per frame
	void Update () 
	{}

	void Spawn() 
	{
		int i = Random.Range (0, game.spawnObjects.Count);
		//int j = Random.Range (0, colors.Length);
		GameObject shapeObject = (GameObject)Instantiate (game.spawnObjects [i], transform.position, game.spawnObjects[i].transform.rotation);
		Shape shapeComponent = shapeObject.GetComponent<Shape>();

		shapeComponent.SetDirection( direction );
		shapeComponent.SetVelocity( shapeInitialVelocity );
		//shape.renderer.material = colors [j];

		//Debug.Log ("SPAWNED ITEM"); 

		if( !pauseSpawning )
			Invoke ("Spawn", game.spawnDelay);
	}
	
}
