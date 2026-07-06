using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public Animator animator;
    public Transform[] transforms;
    public SpriteRenderer sp;
    public Sprite sprite;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
    public Inputcontoller inputcontoller;
    bool immortal = false;

    public Cinemachine.CinemachineVirtualCamera vcam;
    bool isGameOver = false;
    float timer = 0f;
    Vector3 targetposition;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {  
        if(collision.gameObject.CompareTag("Enemy") && !animator.GetBool("Powerup") && !immortal)
        {
            foreach (Transform t in transforms)
            {
                t.gameObject.SetActive(false);
            }

            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);
            boxCollider2D.enabled = false;
            inputcontoller.enabled = false;
            vcam.Follow = null;
            animator.enabled = false;

            
            sp.sprite = sprite;
            targetposition = transform.position;
            isGameOver = true;
        }
        else if(collision.gameObject.CompareTag("Enemy") && animator.GetBool("Powerup"))
        {
            animator.SetBool("Powerup", false);
            StartCoroutine(Tme());
        }
    }

    IEnumerator Tme()
    {
        immortal = true;
        yield return new WaitForSeconds(1f);
        immortal = false;
    }

    void OnBecameInvisible()
    {
        if (!isGameOver)
        {
            foreach (Transform t in transforms)
            {
                t.gameObject.SetActive(false);
            }

            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);
            boxCollider2D.enabled = false;
            inputcontoller.enabled = false;
            vcam.Follow = null;
            animator.enabled = false;


            sp.sprite = sprite;
            targetposition = transform.position;
            isGameOver = true;
        }
    }

    private void Update()
    {
        if (isGameOver)
        {
            timer += Time.deltaTime;
            if (timer > 4f)
            {
                Restart();
            }
        }
    }
}
