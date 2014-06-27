using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	RuntimePlatform platform = Application.platform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
			// Mobile controls
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					checkTouch(Input.GetTouch(0).position);
				}
			}
		} else*/ if(platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor){

			//Debug.Log ("OMG");	
			// Windows controls
			if(Input.GetMouseButtonDown(0)){
				checkTouch(Input.mousePosition); 
			}
		}


	}


	void checkTouch(Vector2 position) {
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint (position);
		Vector2 touchPosition = new Vector2 (worldPoint.x, worldPoint.y);

		Collider2D hit = Physics2D.OverlapPoint (touchPosition);

		Debug.Log (hit);

		if (hit) {
			Debug.Log (hit.transform.gameObject.name);
		}
	}
}
