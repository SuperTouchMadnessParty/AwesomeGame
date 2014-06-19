using UnityEngine;
using System.Collections;

public class MoveShape : MonoBehaviour {

	public float moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.down * Time.deltaTime * moveSpeed;
	}
}
