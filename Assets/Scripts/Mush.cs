using UnityEngine;

public class Mush : MonoBehaviour
{
   Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator = collision.gameObject.GetComponent<Animator>();
            animator.SetBool("Powerup", true);
            Destroy(gameObject);
        }
    }
}

