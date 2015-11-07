using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Shape : MonoBehaviour 
{
	public GameObject explosionEffect;

	private bool affectedByGravity = false;
	private float acceleration = 0.0f;
	public float velocity = 1.75f;
	private Vector3 direction = new Vector3( 0.0f, 0.0f, 0.0f );
	private AwesomeGame awesomeGame;
    public Guid id;
	public float spawnSpeedMod;
    private bool bIlum = false;
    private float maxRange = 1.95f;

	// Use this for initialization
	void Start () 
	{
		GameObject game = GameObject.Find ( "Game" );
		if (game != null) 
		{
			awesomeGame = game.GetComponent<AwesomeGame> ();
			spawnSpeedMod = awesomeGame.SpeedModifier;
        }


        if(awesomeGame.shapeToClick.GetComponent<Renderer>().sharedMaterial == this.GetComponent<Renderer>().sharedMaterial)
        {
            ToggleHighlight(true);
        }

        id = Guid.NewGuid();

	}

	void Update()
	{
		if( awesomeGame )
		{

            if ( !awesomeGame.GetComponent<Collider>().bounds.Intersects( this.GetComponent<Collider>().bounds ) )
			{
				awesomeGame.ShapeFellOutOfBounds( this );
                awesomeGame.activeShapes.RemoveAll(p => p.GetComponent<Shape>().id == this.id);
                Destroy( gameObject );
			}


            if (bIlum && this.GetComponent<Light>().range < maxRange)
            {
                this.GetComponent<Light>().range += 0.2f;
            }
            else if (!bIlum && this.GetComponent<Light>().range > 0)
            {
                this.GetComponent<Light>().range -= 0.2f;
            }
        }
	}

	void FixedUpdate () 
	{
		//if( affectedByGravity )
		if( awesomeGame )
		{
			if(spawnSpeedMod < awesomeGame.SpeedModifier)
			{
				spawnSpeedMod = awesomeGame.SpeedModifier;
				UpdateVelocity();
			}


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

	public void ToggleHighlight(bool bOn) {
		if(this.gameObject.GetComponent<Light>() != null)
		{
			if(bOn){
				this.gameObject.GetComponent<Light>().enabled = true;
                bIlum = true;
			}
			else {
				this.gameObject.GetComponent<Light>().enabled = false;
                this.gameObject.GetComponent<Light>().range = 0;
                bIlum = false;
            }
		}
	}

	private void UpdateVelocity() {
		// Initial shape velocity plus the incremental value
		// TODO: Bring in the initial velocity from the spawners to make changes smoother
		SetVelocity (1.75f + spawnSpeedMod);
	}
}
