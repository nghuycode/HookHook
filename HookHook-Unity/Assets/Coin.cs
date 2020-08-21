using PUser;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private void OnTriggerEnter2D(Collider2D other) {
        UserRepository.AddMoney(1);
        animator.SetTrigger("EatCoin");
    }
}
