using UnityEngine;

public class WallColliding : MonoBehaviour
{
    public Wandering Wandering;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            Wandering.ChangeDirection();     
    }

}
