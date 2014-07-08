using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AwesomeGame : MonoBehaviour 
{
	public GameObject shapeToClick;

	public List<GameObject> spawnObjects = new List<GameObject>();
	public float spawnDelay = 1;

	// Use this for initialization
	void Start () 
	{
		ChangeShape();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void ChangeShape()
	{
		//shapeToClick.renderer.material = spawnObjects[Random.Range(0, spawnObjects.Count)].renderer.material;
		Invoke ( "ChangeShape", 1.0f );
	}
}
