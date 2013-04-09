using UnityEngine;
using System.Collections;
 
public class lerpexample : MonoBehaviour {
 
    Vector3 startRot = new Vector3(-30.0f,-30.0f,-30.0f);
    Vector3 endRot   = new Vector3(60.0f, 60.0f, 60.0f);
 
    int armstate = 0;
    float duration = 20.0f;
    float timer = 0.0f;
 
    void Update () {
 
       timer += Time.deltaTime;
       if (timer > duration) {
         armstate = (armstate + 1) % 2;
         timer = 0.0f;
       }
 
       if (armstate == 0) { 
           transform.eulerAngles = Vector3.Lerp (startRot,endRot,timer/duration);
       }
 
       if (armstate == 1) { 
         transform.eulerAngles = Vector3.Lerp (endRot,startRot,timer/duration);
       }
    }
}