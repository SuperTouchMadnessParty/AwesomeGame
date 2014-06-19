using UnityEngine;
using System.Collections;

public class SpawnShapes : MonoBehaviour {

	public GameObject[] spawnObjects;
	//public Material[] colors;
	public float spawnTime;


	// Use this for initialization
	void Start () {
		Invoke ("Spawn", spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn() {
		int i = Random.Range (0, spawnObjects.Length);
		//int j = Random.Range (0, colors.Length);
		GameObject shape = (GameObject) Instantiate (spawnObjects [i], transform.position, spawnObjects[i].transform.rotation);

		//shape.renderer.material = colors [j];

		Debug.Log ("SPAWNED ITEM");

		Invoke ("Spawn", spawnTime);
	}
	
}
