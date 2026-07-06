using UnityEngine;

public class bump : MonoBehaviour
{
    public Inputcontoller inputController;
    public bool ishard = false;
    public Animator animator;
    void OnTriggerEnter2D(Collider2D collision)
    {
        inputController.Headbump();
    }

    private void Update()
    {
        ishard = animator.GetBool("Powerup");
    }
}
