using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerView : View<GameplayApp>
{
    public GameObject Target;
    public SpriteRenderer sprite;
    public LineRenderer rope;
    public TrailRenderer trail;
    public Rigidbody2D rb;
    public DistanceJoint2D distanceJoint;
    public Animator anim;
    [SerializeField]
    private Vector3 trailOffset, ropeOffset;
    [SerializeField]
    private float borderUp, borderDown;

    #region MONO BEHAVIOUR
    private void Start()
    {
        Target = GameObject.Find("Award");
        rb = this.GetComponent<Rigidbody2D>();
        distanceJoint = this.GetComponent<DistanceJoint2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (app.model.PlayerModel.CanPlay)
        {
            flipWithVelocity();
            animationPlayer();
            checkPlayerOutBorder();
        }
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
        float forceScale = 2;
        if (!sprite.flipX)
            rb.AddForce(Vector2.right * forceScale, ForceMode2D.Impulse);
        else
            rb.AddForce(Vector2.left * forceScale, ForceMode2D.Impulse);
    }
    private void animationPlayer()
    {
        anim.SetBool("IsSwinging", app.model.PlayerModel.IsSwinging);
    }
    private void checkPlayerOutBorder()
    {
        if (this.transform.position.y > borderUp || this.transform.position.y < borderDown)
        {
            //Lose
            app.controller.PlayerController.PlayerLose();
        }
    }
    private void checkPlayerProgressMap()
    {
        app.controller.PlayerController.UpdateProgressMap(this.transform.position.x / Target.transform.position.x);
    }
    public void OnShootRope()
    {
        addInitForce();   
        OnSwingRope();
    }
    public void OnSwingRope()
    {
        rope.enabled = true;

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
    public void OnPlayerWin()
    {
        StartCoroutine(WinAnimation());
    }
    IEnumerator WinAnimation()
    {
        rope.enabled = false;
        anim.SetBool("IsWinning", true);

        distanceJoint.enabled = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;

        sprite.flipX = true;
        yield return new WaitForSeconds(.5f);
        sprite.flipX = false;
        yield return new WaitForSeconds(.5f);
        rb.AddForce(Vector2.right * 100, ForceMode2D.Impulse);
    }
    public void OnPlayerLose()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (app.model.PlayerModel.CanPlay)
        {
            if (collision.gameObject.CompareTag("Award"))
            {
                app.controller.PlayerController.PlayerWin();
            }
        }
    }
    private Anchor FindNextAnchor()
    {
        return AnchorManager.Instance? 
            AnchorManager.Instance.FindNearestAnchorWithPlayer(this.transform.position, app.model.PlayerModel.IsSwinging) : null;
    }
    #endregion
}
