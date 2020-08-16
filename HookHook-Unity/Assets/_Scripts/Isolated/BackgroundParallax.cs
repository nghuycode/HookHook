using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private float length, startPos;
    private Camera cam;

    [SerializeField]
    private float parallaxEffect;

    private void Start()
    {
        cam = Camera.main;
        startPos = this.transform.position.x;
        length = this.GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        float tmp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (tmp > startPos + length) startPos += length;
        else if (tmp < startPos - length) startPos -= length;   
    }
}
