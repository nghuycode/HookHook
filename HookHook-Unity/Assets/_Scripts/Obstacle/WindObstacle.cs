using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindObstacle : AbstractObstacle
{
    public override void Affect(GameObject go)
    {
        //go.GetComponent<Rigidbody2D>().AddForce()
    }

    public override void RunAnimation()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        AudioManager.AM.Play("Wind");
        Affect(other.gameObject);
    }
}