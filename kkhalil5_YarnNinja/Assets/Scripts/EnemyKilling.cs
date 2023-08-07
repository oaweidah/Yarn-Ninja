using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKilling : MonoBehaviour
{
     public static int enemies = 3;

    [SerializeField] bool isBoss;
    [SerializeField] public static int numBossLives = 2;
    [SerializeField] private Text enemiesText;
    [SerializeField] private AudioSource killingSoundEffect;
    [SerializeField] private AudioSource damageSoundEffect;
    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(!isBoss){
                Destroy(collision.gameObject);
                enemies--;
                enemiesText.text = "Enemies Remaining: " + enemies;
                killingSoundEffect.Play();
            }
            else if(isBoss)
            {
                rb.velocity = new Vector3(0,0,0);
                if(numBossLives > 0)
                {
                    damageSoundEffect.Play();
                    numBossLives--;
                    Debug.Log(numBossLives);
                }
                else if(numBossLives == 1)
                {
                    // This is where we would either add spikes all over the floor or 2 saws that move along the entire path
                    // changing layer is easy, its getting a reference to the specific sprite that I could not figure out
                }
                else if(numBossLives == 0)
                {
                    Destroy(collision.gameObject);
                    Destroy(transform.parent.gameObject.gameObject);
                    killingSoundEffect.Play();
                }
            }
        }
    }
}
