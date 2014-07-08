using UnityEngine;
using System.Collections;

public class DestroyOnInvis : MonoBehaviour {
	
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
	
}
