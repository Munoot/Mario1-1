using UnityEngine;

public class Head : MonoBehaviour
{
    public Animator animator;
    public GameObject head;
    void Update()
    {
        if(animator.GetBool("OnAir"))
        {
            head.SetActive(true);
        }
        else
        {    
            head.SetActive(false);        
        }
    }
}
