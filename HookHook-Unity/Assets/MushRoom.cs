using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void OnCollisionEnter2D(Collision2D other) {
        animator.SetBool("Touch",true);
        AudioManager.AM.Play("PlayerBounce");
    }

    private void OnCollisionExit2D(Collision2D other) {
        animator.SetBool("Touch",false);
    }
}
