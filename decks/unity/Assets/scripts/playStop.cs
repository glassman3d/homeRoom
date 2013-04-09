using UnityEngine;
using System.Collections;

public class playStop : MonoBehaviour {
	
	public physicsSpinFunctions mat;
	
	void OnMouseDown () {
		
		Debug.Log ("mouse pressed");
		
		mat.playState();
		
	}
}
