using System.Collections;
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

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        distanceJoint = this.GetComponent<DistanceJoint2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        rope = this.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        flipWithVelocity();
    }
    private void flipWithVelocity()
    {
        if (rb.velocity.x > 0)
            sprite.flipX = false;
        if (rb.velocity.x < 0)
            sprite.flipX = true;
    }
    private void addInitForce()
    {
        float forceScale = 50;
        if (!sprite.flipX)
            rb.AddForce(Vector2.right * forceScale, ForceMode2D.Impulse);
        else
            rb.AddForce(Vector2.left * forceScale, ForceMode2D.Impulse);
    }
    public void OnShootRope()
    {
        //addInitForce();   
        OnSwingRope();
    }
    public void OnSwingRope()
    {
        //Line Renderer
        rope.SetPosition(0, this.transform.position);
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private Anchor FindNextAnchor()
    {
        return AnchorManager.Instance.FindNearestAnchorWithPlayer(this.transform.position, app.model.PlayerModel.IsSwinging);
    }
}
