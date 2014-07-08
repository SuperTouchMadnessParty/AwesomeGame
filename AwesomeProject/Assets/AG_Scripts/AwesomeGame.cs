using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AwesomeGame : MonoBehaviour 
{
	public GameObject shapeToClick;

	public List<GameObject> spawnObjects = new List<GameObject>();
	public List<Material> mats = new List<Material> ();
	public float spawnDelay = 1;
	public float shapeChangeDelay = 5;

	// Use this for initialization
	void Start () 
	{
		shapeToClick = GameObject.Find ("ShapeToClick");
		ChangeShape();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void ChangeShape()
	{
		int i = Random.Range (0, mats.Count);

		shapeToClick.renderer.material = mats [i];
		shapeToClick.tag = spawnObjects [i].tag;

		Invoke ( "ChangeShape", shapeChangeDelay );
	}
}
