using UnityEngine;
using System.Collections;

public float timer = 2.0f;

public class CurrentShape : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float nextTime = 0.0f;

		if(nextTime > timer){
			// Change Shape

		}

		nextTime += Time.DeltaTime;
	}
}
