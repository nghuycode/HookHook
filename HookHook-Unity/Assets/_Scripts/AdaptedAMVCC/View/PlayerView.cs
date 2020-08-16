﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerView : View<GameplayApp>
{
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private LineRenderer rope;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private DistanceJoint2D distanceJoint;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private TrailRenderer trail;
    [SerializeField]
    private Vector3 trailOffset, ropeOffset;

    #region MONO BEHAVIOUR
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        distanceJoint = this.GetComponent<DistanceJoint2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
        //rope = this.GetComponent<LineRenderer>();
        //trail = this.GetComponent<TrailRenderer>();
    }
    private void FixedUpdate()
    {
        flipWithVelocity();
        animationPlayer();
    }
    #endregion

    #region PLAYER VIEW BEHAVIOUR
    private void flipWithVelocity()
    {
        if (rb.velocity.x >= 0)
        {
            sprite.flipX = false;
            trail.transform.position = this.transform.position - trailOffset;
        }
        else
        {
            sprite.flipX = true;
            trail.transform.position = this.transform.position + trailOffset;
        }
    }
    private void addInitForce()
    {
        float forceScale = 10;
        if (!sprite.flipX)
            rb.AddForce(Vector2.right * forceScale, ForceMode2D.Impulse);
        else
            rb.AddForce(Vector2.left * forceScale, ForceMode2D.Impulse);
    }
    private void animationPlayer()
    {
        anim.SetBool("IsSwinging", app.model.PlayerModel.IsSwinging);
    }
    public void OnShootRope()
    {
        addInitForce();   
        OnSwingRope();
    }
    public void OnSwingRope()
    {
        //Line Renderer
        rope.SetPosition(0, this.transform.position + ropeOffset);
        rope.SetPosition(1, FindNextAnchor().transform.position);
        rope.enabled = true;

        //Distance Joint 2D
        distanceJoint.enabled = true;
        distanceJoint.connectedBody = FindNextAnchor().rb;
    }
    public void OnReleaseRope()
    {
        rope.enabled = false;

        distanceJoint.connectedBody = null;
        distanceJoint.enabled = false;

        AnchorManager.Instance.UnlockAnchor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Award"))
        {
            Debug.Log("Win Game");
        }
    }
    private Anchor FindNextAnchor()
    {
        return AnchorManager.Instance.FindNearestAnchorWithPlayer(this.transform.position, app.model.PlayerModel.IsSwinging);
    }
    #endregion
}
