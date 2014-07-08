using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShapeSpawner : MonoBehaviour 
{
	public AwesomeGame game;

	// Use this for initialization
	void Start () 
	{
		Invoke ("Spawn", game.spawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn() 
	{
		int i = Random.Range (0, game.spawnObjects.Count);
		//int j = Random.Range (0, colors.Length);
		GameObject shape = (GameObject) Instantiate (game.spawnObjects [i], transform.position, game.spawnObjects[i].transform.rotation);

		//shape.renderer.material = colors [j];

		//Debug.Log ("SPAWNED ITEM"); 

		Invoke ("Spawn", game.spawnDelay);
	}
	
}
