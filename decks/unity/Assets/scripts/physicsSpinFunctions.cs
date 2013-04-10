using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]

public class physicsSpinFunctions : MonoBehaviour {
	
	public armAnim arm;
	
	public float curAngFreq;
	public float targetAngFreq;
	public float absTargAngFreq;
	//public float sqTargetAngFreq;
	public int playstate;
	private Rigidbody rb;
	public float spinAmount;
	/*private Vector3 mouseDragStartPos;
	private Vector3 mouseDragEndPos;
	private Vector3 mouseDragDirection;
	private float mouseDragMagnitude;
	private int mouseDrag;*/
	
	//spinstate: 
	// 0 = stopped
	// 1 = spinUp
	// 2 = playing
	// 3 = spindown

	void Start () {
	
		// initialise all variables
		rb = rigidbody;
		playstate = 0;
		absTargAngFreq = 5f;
		targetAngFreq = 5f;
		spinAmount = 50f;
		rb.angularDrag = 0f ;
		/*mouseDragStartPos = Vector3.zero;
		mouseDragEndPos = Vector3.zero;
		mouseDragDirection = Vector3.zero;
		mouseDragMagnitude = 0f;
		mouseDrag = 0;*/
		
	}
	
	void Update () {
		
		// moved audio to record now!!
		//audio.pitch = curAngFreq / absTargAngFreq;
		
		
	}
	
	
	void FixedUpdate () {
		
		
		rb.maxAngularVelocity = targetAngFreq;
		curAngFreq = rb.angularVelocity.magnitude;
		
		
		if( playstate == 0){
				stop();
			}
			
		if ( playstate == 1 ){
				spinUp ();
			}
			
		if ( playstate == 2 ){
				play ();
			}
			
		if ( playstate == 3 ){
				
				spinDown ();
		}
		
		
	}
	
	/*
	void OnMouseDown() {
		
		rb.angularVelocity = Vector3.zero;
		
	}
	
	void OnMouseUp() {
		
		if (playstate != 0){

			float oldSpinAmount = spinAmount;
			float oldDragAmount = rb.angularDrag;
			rb.angularDrag = 0f;
			spinAmount = 500f;
			spinUp();
			spinAmount = oldSpinAmount;
			rb.angularDrag = oldDragAmount;
		}			
	}
	
	
	void onMouseDrag() {
		
		mouseDragDirection = mouseDragEndPos - mouseDragStartPos;
		
		mouseDragDirection.y = 0f;
		mouseDragDirection.z = 0f;
		
		mouseDragDirection.Normalize();
		

		rb.AddTorque(transform.up * mouseDragDirection.x * mouseDragMagnitude);
		play ();
	}
	
	float calculateMouseDragVelocity() {
	
		return Mathf.Clamp((mouseDragEndPos - mouseDragStartPos).sqrMagnitude / 100, 1f, 1000f);
		
	}
	*/
	
	private void spinUp(){
		
		Debug.Log ("spinUp called");
		
		playstate = 1;
		spinAmount = 50f;
		rb.angularDrag = 0f;
		if (curAngFreq < targetAngFreq){
			
			rb.AddTorque(transform.up * spinAmount *  Time.deltaTime);
			
		}
		else {
			play();
		}
	}
	
	private void play() {
		
		Debug.Log ("play called");
		
		playstate = 2;
		spinAmount = 500f;
		rb.angularDrag = 0f;
		rb.AddTorque(transform.up * spinAmount * Time.deltaTime);
		
	}
	
	private void spinDown() {
		
		Debug.Log ("spinDown called");
		
		playstate =3;
		spinAmount = 50f;
		rb.angularDrag = 0.5f;
		if (curAngFreq == 0f){
			
			stop();
			arm.endAnim();
			
		}
		
	}
	
	private void stop() {
		
		Debug.Log ("stop called");
		
		playstate = 0;
		spinAmount = 50f;
		rb.angularDrag = 1;
		
		
	}
	
	public void playState () {
		
			
		Debug.Log ("playState called");
		
        if( playstate == 0){
			
			arm.startAnim();
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
	
	public void changeTargFreq (float newFreq) {
		
		// i am clamping these values in the pitch control to allow max changes +- 5 bpm
		
		targetAngFreq = newFreq;
		
	}
	
	public Vector3 returnPos () {
		
		return transform.position;
		
	}
	
	public Vector3 returnRot () {
		
		return transform.eulerAngles;
		
	}
	
	public float returnAngVel () {
		
		return curAngFreq;
		
	}
	
}
