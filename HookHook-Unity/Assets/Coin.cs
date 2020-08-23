using PUser;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player")
        {
            AudioManager.AM.Play("EatCoin");
            animator.SetTrigger("EatCoin");
        }
    }
    IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(this.gameObject);
    }
}
