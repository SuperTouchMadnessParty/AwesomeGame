using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public float screenDuration;

	void Start () 
	{
		Invoke ( "LoadNextScreen", screenDuration );
	}
	
	// Update is called once per frame
	void Update () 
	{}

	void LoadNextScreen()
	{
		Application.LoadLevel( Application.loadedLevel + 1 );
	}
}
