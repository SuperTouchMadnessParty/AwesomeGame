using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	RuntimePlatform platform = Application.platform;

	
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this);
		ShapeToClick = GameObject.Find ("ShapeToClick");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Debug.Log ( Application.loadedLevel );
			
			if( Application.loadedLevel == 0 )
				Application.Quit();
			
			else
				Application.LoadLevel( 0 );
		}
		
	}
	
	void checkTouch(Vector2 position) 
	{

	}
}