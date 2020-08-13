using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer LockRound;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    public void OnLocking()
    {
        LockRound.enabled = true;
    }
    public void OnUnlocking()
    {
        LockRound.enabled = false;
    }
}
