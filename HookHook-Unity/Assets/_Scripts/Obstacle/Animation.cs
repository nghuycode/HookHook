using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField]
    float speedMin = 1f;
    [SerializeField]
    float SpeedMax = 5f;
    //adjust this to change how high it goes
    [SerializeField]
    float HeightMin = 0.5f;
    [SerializeField]
    float HeightMax = 1f;
    private float speed;
    private float height;

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        speed = Random.Range(speedMin,SpeedMax);
        height = Random.Range(HeightMin,HeightMax);
    }
    void Update()
    {

        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z) ;
    }
}
