using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer lockRound, anchorSprite;
    [SerializeField]
    private Sprite lockAnchorSprite, unlockAnchorSprite;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anchorSprite = this.GetComponent<SpriteRenderer>();     
    }
    public void OnLocking()
    {
        if (lockRound)
        {
            lockRound.enabled = true;
            anchorSprite.sprite = lockAnchorSprite;
        }
    }
    public void OnUnlocking()
    {
        if (lockRound)
        {
            lockRound.enabled = false;
            anchorSprite.sprite = unlockAnchorSprite;
        }
    }
}
