﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AwesomeGame : MonoBehaviour 
{
	public GameObject shapeToClick;

	public List<GameObject> spawnObjects = new List<GameObject>();
	public List<Material> mats = new List<Material> ();
	public float spawnDelay = 1;
	public float shapeChangeDelay = 5;
	public GameObject incorrectExplosion;

	private bool startingNextRound = false;
	private int round;
	private HealthMeter healthMeter;
	private RuntimePlatform platform = Application.platform;

	// Use this for initialization
	void Start () 
	{
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

		if( startingNextRound )
		{

		}
	}

	void checkTouch(Vector2 position) 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast ( ray, out hit, Mathf.Infinity, 5 ) && hit.transform.gameObject.tag == "Shape" ) 
		{
			Shape shape = hit.transform.gameObject.GetComponent< Shape >();
			Debug.Log (shape.name);

			if(shape.gameObject.renderer.material.name == shapeToClick.gameObject.renderer.material.name) 
			{
				Debug.Log ("YOU DID IT CHAMP!");
				healthMeter.RestoreHealth();
				SpawnExplosion( shape.explosionEffect, shape.transform.position, shape.transform.rotation );
			}
			else
			{
				healthMeter.TakeDamage();
				SpawnExplosion( incorrectExplosion, shape.transform.position, shape.transform.rotation );
			}

			Destroy(hit.transform.gameObject);
		}
	}

	public void ShapeFellOutOfBounds( Shape shape )
	{
		if( shape.gameObject.renderer.material.name == shapeToClick.renderer.material.name )
		{
			healthMeter.TakeDamage();
		}
	}

	void ChangeShape()
	{
		int i = Random.Range (0, mats.Count);

		shapeToClick.renderer.material = mats [i];

		Invoke ( "ChangeShape", shapeChangeDelay );
	}

	public void SpawnExplosion( GameObject particleEffect, Vector3 position, Quaternion rotation )
	{
		Instantiate( particleEffect, position, rotation );
	}
}
