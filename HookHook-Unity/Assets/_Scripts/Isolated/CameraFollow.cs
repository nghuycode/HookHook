using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset, newPosition;
    public bool followX, followY;
    public float speedFollow;
    void LateUpdate()
    {
        newPosition = this.transform.position;
        if (followX)
            newPosition = new Vector3(target.position.x + offset.x, newPosition.y, newPosition.z);
        if (followY)
            newPosition = new Vector3(newPosition.x, target.position.y + offset.y, newPosition.z);
        newPosition = Vector3.Lerp(this.transform.position, newPosition, speedFollow);
        this.transform.position = newPosition;
    }
}
