using UnityEngine;

public class Wandering : MonoBehaviour
{
    Vector3 v  = new Vector3(1f, 0, 0);
    bool visible = false;
    public void ChangeDirection()
    {
        v = -v;
    }

    void OnBecameVisible()
    {
        visible = true;
    }
    void Update()
    {
        if(!visible)
                return;

        transform.position -= v * Time.deltaTime;
    }
}
