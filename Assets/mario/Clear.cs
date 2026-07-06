using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera vcam;
    public GameObject player;
    Vector3 position;
    bool clear = false;
    public Animator flag;

    void OnTriggerEnter2D(Collider2D collision)
    {  
        if(collision.gameObject.CompareTag("Player"))
        {
            vcam.Follow = null;
            position = player.transform.position;
            player.GetComponent<Inputcontoller>().enabled = false;
            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            player.GetComponent<Animator>().SetBool("OnMove", false);
            flag.SetBool("Clear", true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        clear = true;
    }

    void Update()
    {
        if (clear)
        {
            player.GetComponent<Animator>().SetBool("OnMove", true);
            player.GetComponent<Animator>().SetBool("Sliding", false);
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 0.3f, ForceMode2D.Force);
        }
    }
}
