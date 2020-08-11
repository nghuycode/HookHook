using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public Rigidbody2D rb;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    public void OnLocking()
    {

    }
}
