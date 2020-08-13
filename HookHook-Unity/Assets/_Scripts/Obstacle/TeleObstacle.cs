using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleObstacle : AbstractObstacle
{

    public GameObject OutPort;
    public override void Affect(GameObject go)
    {
        go.GetComponent<PlayerController>().ReleaseRope();
        go.transform.position = OutPort.transform.position;
    }

    public override void RunAnimation()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Affect(other.gameObject);
    }
}