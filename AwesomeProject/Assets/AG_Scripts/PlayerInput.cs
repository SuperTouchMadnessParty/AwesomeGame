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
	void Update () 
	{
		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) 
		{
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					checkTouch(Input.GetTouch(0).position);
				}
			}
		} 
		
		// Windows controls
		else if(platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor)
		{
			if(Input.GetMouseButtonDown(0))
			{
				checkTouch(Input.mousePosition); 
			}
		}

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
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast ( ray, out hit, Mathf.Infinity, 5 ) ) 
		{

		}
	}
}