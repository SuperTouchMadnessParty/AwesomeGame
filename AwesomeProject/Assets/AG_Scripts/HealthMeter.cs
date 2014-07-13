using UnityEngine;
using System.Collections;

public class HealthMeter : MonoBehaviour 
{
	public float health = 100;
	public float maxHeath = 100;
	public float difficulty = 1;
	public float damageToTake = 10.0f;
	public float healthToGain = 5.0f;
	private float startingScale;

	// Use this for initialization
	void Start ()
	{
		startingScale = transform.localScale.y;
		if( health > maxHeath )
			health = maxHeath;
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	public void TakeDamage()
	{
		health -= damageToTake * difficulty;
		if( health < 0 )
			health = 0;

		float healthPercent =  health / maxHeath;
		float newScale = healthPercent * startingScale;
		transform.localScale = new Vector3( transform.localScale.x, newScale, transform.localScale.z );
	}

	public void RestoreHealth()
	{
		health += healthToGain * difficulty;
		if( health > maxHeath )
			health = maxHeath;

		float healthPercent =  health / maxHeath;
		float newScale = healthPercent * startingScale;
		transform.localScale = new Vector3( transform.localScale.x, newScale, transform.localScale.z );
	}
}
