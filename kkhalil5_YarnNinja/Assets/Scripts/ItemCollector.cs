using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int shurikens = 0;
    [SerializeField] private Text shurikensText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Shuriken"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            shurikens++;
            shurikensText.text = "Shurikens:" + shurikens;
        }
    }
}
