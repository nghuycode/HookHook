using  UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SlowTimeObstacle : MonoBehaviour 
{

    private void OnTriggerEnter2D(Collider2D other) {
        Time.timeScale = 0.4f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }    

    private void OnTriggerExit2D(Collider2D other) {
        Time.timeScale = 1;
    }
}