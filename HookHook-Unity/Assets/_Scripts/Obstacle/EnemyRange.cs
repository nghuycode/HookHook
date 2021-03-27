using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public GameplayApp App;
    public float Speed;
    public float Range;
    private PlayerView player;
    private bool isPlayerNear = false;
    void Start()
    {
        player = App.view.PlayerView;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,Speed*Time.deltaTime);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(transform.position, Range);
    }

}
