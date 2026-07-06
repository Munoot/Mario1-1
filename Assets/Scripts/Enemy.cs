using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    Wandering wander;
    bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        wander = GetComponent<Wandering>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
        {
            tag = "Corpses";
            wander.enabled = false;
            animator.SetBool("isDead", true);
            isDead = true;
        }
    }

    void Update()
    {
        if (isDead)
        { 
            Destroy(gameObject, 1f);          
        }
    }
}

