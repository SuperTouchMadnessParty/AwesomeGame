using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuShapeSpawner : MonoBehaviour 
{
	public List<GameObject> spawnObjects = new List<GameObject>();
	public float spawnDelay = 1;

	// Use this for initialization
	void Start () 
	{
		Invoke ("Spawn", spawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn() 
	{
		int i = Random.Range (0, spawnObjects.Count);
		//int j = Random.Range (0, colors.Length);
		GameObject shape = (GameObject) Instantiate (spawnObjects [i], transform.position, spawnObjects[i].transform.rotation);

		//shape.renderer.material = colors [j];

		//Debug.Log ("SPAWNED ITEM"); 

		Invoke ("Spawn", spawnDelay);
	}
	
}
