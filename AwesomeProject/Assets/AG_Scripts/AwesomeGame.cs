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
		shapeToClick.renderer.material = mats [Random.Range (0, mats.Count)];

		Invoke ( "ChangeShape", shapeChangeDelay );
	}
}
