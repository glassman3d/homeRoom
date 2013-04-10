using UnityEngine;
using System.Collections;

public class Record : MonoBehaviour {
	
	public physicsSpinFunctions mat;
	public int playstate;
	
	// playstate
	// 0 - slave
	// 1 - mouseDown
	// 2 - drag
	// 3 - release
	
	public Vector3 matpos;
	public Vector3 matrot;
	public float angVel;
	public Vector3 lastPos;
	public Vector3 lastRot;
	public Vector3 curScreenPoint;
	
	// Use this for initialization
	void Start () {
	
		matpos = mat.returnPos() + new Vector3(0f, -0.04f,0f);
		transform.position = matpos;
		playstate = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playstate == 0) {
			matrot = mat.returnRot();
			transform.eulerAngles = matrot;
			angVel = mat.returnAngVel();
			//Debug.Log ("angVel: " + angVel);
			audio.pitch = angVel / 5f;
			
		}
		
		if (playstate == 1) {
			//angVel = 0f;
			lastRot = matrot;
			lastPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
			transform.eulerAngles = lastRot;
			audio.pitch = 0f;
			
		}
		
		if (playstate == 2) {
			curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
			Vector3 deltaPos = curScreenPoint - lastPos;
		
			Debug.Log("deltaPos; " + deltaPos);
		
			if (deltaPos.x > 64f) {
				deltaPos.x = 64f;
			}
			
			if (deltaPos.x < -117f) {
				deltaPos.x = -117f;
			}
			
			transform.eulerAngles = lastRot + new Vector3(0f,deltaPos.x/1f,0f);
			
			float t = (deltaPos.x + 117f) /181f; 
			
			audio.pitch = Mathf.Lerp(-1f,1f,t);
			lastRot = transform.eulerAngles;
		}
		
		
	}
	
	// 
	void OnMouseDown () {
		
		playstate = 1;
		
	}
	
	void OnMouseDrag () {
		
		playstate = 2;
		
	}
	
	void OnMouseUp () {
		
		playstate = 0;
		
	}
}
