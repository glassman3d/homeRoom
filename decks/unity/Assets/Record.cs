using UnityEngine;
using System.Collections;

public class Record : MonoBehaviour {
	
	public physicsSpinFunctions mat;
	public Vector3 matpos;
	public Vector3 matrot;
	
	// Use this for initialization
	void Start () {
	
		matpos = mat.returnPos() + new Vector3(0f, -0.04f,0f);
		transform.position = matpos;
		
	}
	
	// Update is called once per frame
	void Update () {
	
		matrot = mat.returnRot();
		transform.eulerAngles = matrot;
		
	}
}
