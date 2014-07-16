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
	private AwesomeGame awesomeGame;

	// Use this for initialization
	void Start () 
	{
		GameObject game = GameObject.Find ( "Game" );
		if( game != null )
			awesomeGame = game.GetComponent<AwesomeGame>();
	}

	void Update()
	{
		if( awesomeGame )
		{
			if( !awesomeGame.collider.bounds.Intersects( this.collider.bounds ) )
			{
				awesomeGame.ShapeFellOutOfBounds( this );
				Destroy( gameObject );
			}
		}
	}

	void FixedUpdate () 
	{
		//if( affectedByGravity )
		if( awesomeGame )
		{
			if( !awesomeGame.IsPaused )
			{
				transform.position += direction * velocity * Time.fixedDeltaTime;
			}
		}
		else
		{
			transform.position += direction * velocity * Time.fixedDeltaTime;
		}
	}

 	public void SetDirection( Vector3 direction )
	{
		this.direction = direction;
	}

	public void SetVelocity( float initialVelocity )
	{
		velocity = initialVelocity;
	}
}
