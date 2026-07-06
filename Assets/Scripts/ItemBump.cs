using UnityEngine;

public class ItemBump : MonoBehaviour
{
    bool bumped = false;
    Vector3 Targetposition;
    Vector3 Originalposition;
    float timer = 0f;
    SpriteRenderer sr;
    public Sprite sprite;
    public GameObject itemPrefab;
    FramePlayer fp;

    void Start()
    {
        Targetposition = transform.position;
        Originalposition = transform.position;
        sr = GetComponent<SpriteRenderer>();
        fp = GetComponent<FramePlayer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Head") && !bumped)
        {
            Targetposition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            fp.enabled = false;
            sr.sprite = sprite;
            if(itemPrefab != null)
            {
                Instantiate(itemPrefab, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
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
                timer = 0f;

                Targetposition = Originalposition;
            }
        }
    }
}

