using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFeatures : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Color ogColor;
    float flashTime = .5f;
    public static bool hit;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ogColor = spriteRenderer.color;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ming"));
        {
            hit = true;
            FlashStart();
        }
    }

    void FlashStart(){
        //gameObject.tag = "Untagged";
        spriteRenderer.color = Color.red;
        Invoke("FlashStop", flashTime);
    }

    void FlashStop(){
        //hit = false;
        spriteRenderer.color = ogColor;
        gameObject.tag = "Enemy";
    }
}
