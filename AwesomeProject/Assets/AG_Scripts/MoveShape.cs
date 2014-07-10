using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveShape : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public GameObject explosionEffect;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += Vector3.down * Time.deltaTime * moveSpeed;
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
