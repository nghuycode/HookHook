using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireObstacle : AbstractObstacle
{   
    private void Start() {

    }
    public override void Affect(GameObject go)
    {
    }

    public override void RunAnimation()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D player) { Affect(player.gameObject); }
}