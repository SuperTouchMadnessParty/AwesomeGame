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
			
			if( Application.loadedLevel == 1 )
				Application.Quit();
			
			else
				Application.LoadLevel( 1 );
		}
		
	}
	
	void checkTouch(Vector2 position) 
	{

	}
}