using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	RuntimePlatform platform = Application.platform;

	// Use this for initialization
	void Start () 
	{}
	
	// Update is called once per frame
	void Update () 
	{
		//Mobile Controls
		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) 
		{
			if( Input.touchCount > 0 )
			{
				if( Input.GetTouch(0).phase == TouchPhase.Began )
				{
					checkTouch( Input.GetTouch( 0 ).position );
				}
			}
		}

		//Window Controls
		else if(platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor)
		{
			if( Input.GetMouseButtonDown(0) )
			{
				checkTouch( Camera.main.ScreenToWorldPoint( Input.mousePosition ) ); 
			}
		}
	}


	void checkTouch( Vector2 position ) 
	{
		Application.LoadLevel( 1 );
	}
}
