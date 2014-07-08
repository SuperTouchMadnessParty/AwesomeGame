using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	public GameObject ShapeToClick; 
	RuntimePlatform platform	= Application.platform;
	public float fTimeToSwap = 10.0f;
	private float fTimer = 0.0f;
	
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this);
		ShapeToClick = GameObject.Find ("ShapeToClick");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
			// Mobile controls
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					checkTouch(Input.GetTouch(0).position);
				}
			}
		} else if(platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor){
			
			// Windows controls
			if(Input.GetMouseButtonDown(0))
			{
				checkTouch(Input.mousePosition); 
			}
		}
		
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Debug.Log ( Application.loadedLevel );
			
			if( Application.loadedLevel == 0 )
				Application.Quit();
			
			else
				Application.LoadLevel( 0 );
		}
		
	}
	
	void checkTouch(Vector2 position) {
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit)) {
			
			if(hit.transform.gameObject.tag == ShapeToClick.gameObject.tag) {
				Debug.Log ("YOU DID IT CHAMP!");
			}
			else {
				Debug.Log ("FAILURE!");
			}
			Destroy(hit.transform.gameObject);
		}
	}
}