using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuShapeSpawner : MonoBehaviour 
{
	public List<GameObject> spawnObjects = new List<GameObject>();
	public float spawnDelay = 1;
	
	public Vector3 direction = new Vector3( 0.0f, -1.0f, 0.0f );
	public float shapeInitialVelocity = 1.75f;

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
		GameObject shapeObject = (GameObject)Instantiate (spawnObjects [i], transform.position, spawnObjects[i].transform.rotation);
		Shape shapeComponent = shapeObject.GetComponent<Shape>();
		
		shapeComponent.SetDirection( direction );
		shapeComponent.SetVelocity( shapeInitialVelocity );

		Invoke ("Spawn", spawnDelay);
	}
	
}
