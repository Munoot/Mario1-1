using UnityEngine;

public class FramePlayer : MonoBehaviour
{
    public Sprite[] Sprites;
    float timer = 0;
    int index = 0;
    SpriteRenderer spriterenderer;
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f )
        {
            index++;
            spriterenderer.sprite = Sprites[index];
            
            if (index == Sprites.Length - 1) 
                index = -1;
            timer = 0;
        }



    }
}
