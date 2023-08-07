using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowerBoss : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private Rigidbody2D rb;
    private float invertEnemy = 2f;
    [SerializeField] private bool canTurn;
    int randomNumber;

    [SerializeField] private float speed = 2f;

    private void Start(){
        StartCoroutine(NumberGen());
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position,transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(canTurn){
                rb.transform.localScale = new Vector3(invertEnemy,2f,2f);
                invertEnemy = invertEnemy * -1;
            }
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position,waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
         IEnumerator NumberGen()
            {
                while(true)
                {
                        randomNumber = Random.Range(0, 10);
                        yield return new WaitForSeconds(randomNumber);
                        rb.transform.localScale = new Vector3(invertEnemy,2f,2f);
                        invertEnemy = invertEnemy * -1;
                }
            }
}
