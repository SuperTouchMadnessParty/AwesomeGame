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
	{
		if( Application.platform == RuntimePlatform.Android )
		{
			if(Input.touchCount > 0)
			{
				if(Input.GetTouch(0).phase == TouchPhase.Began)
				{
					LoadNextScreen();
				}
			}
		}
	}

	void LoadNextScreen()
	{
		Application.LoadLevel( Application.loadedLevel + 1 );
	}
}
