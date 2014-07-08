using UnityEngine;
using System.Collections;

public class CurrentShape : MonoBehaviour {

	public float fTimeToSwap = 5.0f;
	private float fTimer = 0.0f;

	public Material[] mats;
	public GameObject[] shapes;

	private GameObject[] spawners;

	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag ("Spawner");
	}
	
	// Update is called once per frame
	void Update () {
		fTimer += Time.deltaTime;

		if (fTimer >= fTimeToSwap) {
			SwapShape();
			fTimer = 0.0f;

			foreach(GameObject g in spawners) {
				g.SendMessage("PauseSpawning");
			}
		}
	}

	void SwapShape(){
		GameObject obj = GameObject.FindGameObjectWithTag ("Player");

		int i = Random.Range (0, mats.Length);

		PlayerInput p = obj.GetComponent ("PlayerInput") as PlayerInput;
		p.ShapeToClick = shapes[i]; 

		renderer.material = mats [i];
	}
}
