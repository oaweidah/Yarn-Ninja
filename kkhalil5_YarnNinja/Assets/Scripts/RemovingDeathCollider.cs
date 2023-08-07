using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingDeathCollider : MonoBehaviour
{

    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(EnemyKilling.numBossLives == 0){
            Destroy(gameObject);
        }
    }
}