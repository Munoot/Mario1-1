using UnityEngine;

public class OnairControl : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    void Start()
    {
        animator.SetBool("OnAir", true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
              animator.SetBool("OnAir", false);
        }
        else if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Corpses"))
        {
            rb.linearVelocityY = 0;
            rb.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
        }
        
    }

}

