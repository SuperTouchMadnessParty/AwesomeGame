using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	RuntimePlatform platform = Application.platform;

	
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Debug.Log ( Application.loadedLevel );
			
			if( Application.loadedLevelName == "MainMenu" )
				Application.Quit();
			
			else
				Application.LoadLevel( "MainMenu" );
		}
		
	}
	
	void checkTouch(Vector2 position) 
	{

	}
}