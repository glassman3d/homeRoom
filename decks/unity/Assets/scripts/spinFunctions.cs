using UnityEngine;
using System.Collections;

public class spinFunctions : MonoBehaviour {
	
	public float currentSpeed;
	public float targetSpeed;
	public int playstate;
	public float transitionTime;
	
	//spinstate: 
	// 0 = stopped
	// 1 = spinUp
	// 2 = playing
	// 3 = spindown
	
	// Use this for initialization
	void Start () {
		
		playstate = 0;
		currentSpeed = 0f;
		targetSpeed = 33.333f;
		transitionTime = 10f;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Debug.Log ("playstate: " + playstate);
		
		if(Input.GetKeyDown(KeyCode.Space)){
			
            if( playstate == 0){
				
				spinUp();
			}
			
			else if ( playstate == 1 ){
				
				spinDown ();
			}
			
			else if ( playstate == 2 ){
				
				spinDown ();
			}
			
			else if ( playstate == 3 ){
				
				spinUp ();
			}
		}
		
		transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
		
	}
	
	private void spinUp(){
		
		Debug.Log ("spinUp called");
		
		playstate = 1;
		smoothy(currentSpeed,targetSpeed, transitionTime);
		play();
		
	}
	
	private void play() {
		
		Debug.Log ("play called");
		
		playstate = 2;
		currentSpeed = targetSpeed = 33.333f;
		
	}
	
	private void spinDown() {
		
		Debug.Log ("spinDown called");
		
		playstate =3;
		smoothy(currentSpeed,0f,transitionTime);
		stop();
		
	}
	
	private void stop() {
		
		Debug.Log ("stop called");
		
		playstate = 0;
		currentSpeed = 0;
		
	}
	
	private void smoothy(float startSpeed, float targetSpeed, float seconds){
		
		Debug.Log ("smoothy called");
		
		float t = 0.0f;
		while(t<= 1.0){
			
			t += Time.deltaTime/seconds;
			transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
			Debug.Log ("t:" + t);
			
		}
		Debug.Log ("t reached!");
	}
}
