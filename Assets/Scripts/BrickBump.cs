using UnityEngine;

public class BrickBump : MonoBehaviour
{
    bool bumped = false;
    Vector3 Targetposition;
    Vector3 Originalposition;
    float timer = 0f;

    void Start()
    {
        Targetposition = transform.position;
        Originalposition = transform.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Head") && !bumped)
        {
            Targetposition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            if(other.gameObject.GetComponent<bump>().ishard)
            {
                Destroy(gameObject);
            }
            bumped = true;
        }

    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Targetposition, Time.deltaTime * 12f);

        if (bumped)
        {
            timer += Time.deltaTime;

            if(timer >= 0.2f)
            {
                bumped = false;
                timer = 0f;

                Targetposition = Originalposition;
            }
        }
    }
}

