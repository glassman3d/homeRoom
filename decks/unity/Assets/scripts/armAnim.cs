using UnityEngine;
using System.Collections;

public class armAnim : MonoBehaviour {
	
	public Vector3 startRot;
	public Vector3 endRot;
	public int armstate;
	public float duration;
	public float startTime;
	public float t;

	// Use this for initialization
	void Start () {
	
		startRot = new Vector3(0,0,0);
		endRot = new Vector3(4,28,0);
		armstate = 0;
		duration = 2f;
		t = 0.0f;
	}
	
	void Update () {
		
		
		
		if (armstate == 1) { 
			
			t +=  Time.deltaTime/duration;
			
			if (t<1.0f) {
			
				//Quaternion.Slerp(Quaternion.LookRotation(startRot,Vector3.up),Quaternion.LookRotation(endRot,Vector3.up),duration);
				transform.eulerAngles = Vector3.Lerp (startRot,endRot,t);
			
			}
			
			else {
				
				t = 0.0f; 
				armstate = 0;
			}
		}
		
		
		if (armstate == 2) { 
			
			t+= Time.deltaTime;
			
			if (t<1.0f) {
		
				//Quaternion.Slerp(Quaternion.LookRotation(endRot,Vector3.up),Quaternion.LookRotation(startRot,Vector3.up),duration);
				transform.eulerAngles = Vector3.Lerp (endRot,startRot,t);
			}
			
			else {
				t=0.0f;
				armstate = 0;
			}
		}
		
	}
	
	public void startAnim () {
		
		Debug.Log("startAnim called");
		armstate = 1;
	}
	
	public void endAnim () {
		
		Debug.Log("endAnim called");
		armstate = 2;
	}
}
