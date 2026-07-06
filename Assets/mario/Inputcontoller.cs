using UnityEngine;
using UnityEngine.InputSystem;

public class Inputcontoller : MonoBehaviour
{
    Animator animator;
    Vector3 Ogscale;
    Rigidbody2D rb;
    bool jump = false;
    bool headbump = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Ogscale = transform.localScale;
    }

    public void Headbump()
    {
        headbump = true;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Keyboard.current.spaceKey.isPressed || Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) && !jump)
        {
            animator.SetBool("OnAir", true);
            rb.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
            jump = true;
        }
        else if (rb.linearVelocity.y == 0 && !animator.GetBool("OnAir") && jump)
        {
            jump = false;
            headbump = false;
        }

        if(!(Keyboard.current.spaceKey.isPressed || Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) && rb.linearVelocity.y > 0 || headbump)
        {
            rb.AddForce(Vector2.down * 1f, ForceMode2D.Force);
        }

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            animator.SetBool("OnMove", true);

            if(rb.linearVelocity.x > 0)
            {
                animator.SetBool("Sliding", true);
            }
            else
            {
                animator.SetBool("Sliding", false);
                transform.localScale = new Vector3(-Ogscale.x, Ogscale.y, Ogscale.z);
            }              
            rb.AddForce(Vector2.left * 1f, ForceMode2D.Force);

            if (rb.linearVelocity.x < -5f)
            {
                rb.linearVelocity = new Vector2(-5f, rb.linearVelocity.y);
            }
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            animator.SetBool("OnMove", true);

            if (rb.linearVelocity.x < 0)
            {
                animator.SetBool("Sliding", true);
            }
            else
            {
                animator.SetBool("Sliding", false);
                transform.localScale = new Vector3(Ogscale.x, Ogscale.y, Ogscale.z);
            }            
            rb.AddForce(Vector2.right * 1f, ForceMode2D.Force);


            if (rb.linearVelocity.x > 5f)
            {
                rb.linearVelocity = new Vector2(5f, rb.linearVelocity.y);
            }
        }
        else
        {
            animator.SetBool("OnMove", false);
        }       
    }
}
