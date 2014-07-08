using UnityEngine;
using System.Collections;

public class HealthMeter : MonoBehaviour 
{
	private float maxHeath = 100;
	private float health = 100;
	private float difficulty = 1;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	void TakeDamage()
	{
		health -= 10.0f * difficulty;
		float healthPercent =  ( maxHeath - health ) / maxHeath;
		Vector3 delta = new Vector3( 0.0f, ( healthPercent * 1.35f ), 0.0f );
		transform.position = startPosition - delta;
	}

	void RestoreHealth()
	{

	}
}
