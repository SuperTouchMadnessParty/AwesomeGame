using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shape : MonoBehaviour 
{
	public GameObject explosionEffect;

	private bool affectedByGravity = false;
	private float acceleration = 0.0f;
	private float velocity = 1.75f;
	private Vector3 direction = new Vector3( 0.0f, 0.0f, 0.0f );

	// Use this for initialization
	void Start () 
	{}

	void FixedUpdate () 
	{
		if( affectedByGravity )

		transform.position += direction * velocity * Time.fixedDeltaTime;
	}

 	public void SetDirection( Vector3 direction )
	{
		this.direction = direction;
	}

	public void SetVelocity( float initialVelocity )
	{
		velocity = initialVelocity;
	}

	void OnBecameInvisible()
	{
		Debug.Log( "Invis Destroy" );
		Destroy (gameObject);
	}
}
