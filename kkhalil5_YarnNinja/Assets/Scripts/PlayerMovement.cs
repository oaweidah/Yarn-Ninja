using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Text jumpText;
    [SerializeField] private int jumpCount;
    [SerializeField] private Text dashText;
    [SerializeField] private int dashCount;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource dashSoundEffect;

    int direction;
    [SerializeField] private bool hasDash;
    private bool canDash;
    private float dashingPower = 30f;
    private float dashingTime = 0.2f;
    private Animator anim;
    private enum MovementState{ idle, jumping }

    private Transform[] children = null;


    [SerializeField] private TrailRenderer tr;

    //Start is called before the first frame update
    void Start()
    {
        children = new Transform[transform.childCount];

        int i = 0;
        foreach(Transform T in transform)
            children[i++] = T;

        anim = GetComponent<Animator>();
        canDash = hasDash;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frames
    private void Update()
    {
        if(findDirection() == 1)
        {
            transform.DetachChildren();
            rb.transform.localScale = new Vector3(1,1,1);
            foreach(Transform T in children)
                T.parent = transform;
        }
        else if(findDirection() == -1)
        {
            transform.DetachChildren();
            rb.transform.localScale = new Vector3(-1,1,1);
            foreach(Transform T in children)
                T.parent = transform;
        }


        if(Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpCount--;
            rb.velocity = new Vector3(0,7f,0);
            jumpSoundEffect.Play();
            jumpText.text = "Jumps Remaining:" + jumpCount;
            StartCoroutine(UpdateAnimationState());
        }

        if(canDash && Input.GetKeyDown(KeyCode.A) && dashCount > 0){
            dashSoundEffect.Play();
            dashCount--;
            direction = -1;
            if(findDirection() == -1)
            {
                direction = direction * -1;
            }
            StartCoroutine(Dash(direction));
            dashText.text = "Dashes Remaining:" + dashCount;
        }

        else if(canDash && Input.GetKeyDown(KeyCode.D) && dashCount > 0){
            dashSoundEffect.Play();
            dashCount--;
            direction = 1;
            if(findDirection() == -1)
            {
                direction = direction * -1;
            }
            StartCoroutine(Dash(direction));
            dashText.text = "Dashes Remaining:" + dashCount;
        }
    }

    private IEnumerator UpdateAnimationState(){
        MovementState state;
        state = MovementState.jumping;
        anim.SetInteger("state", (int)state);
        yield return new WaitForSeconds(0.25f);
        state = MovementState.idle;
        anim.SetInteger("state", (int)state);

    }

    private IEnumerator Dash(int direction){
        float ogGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(direction * transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = ogGravity;
    }

    private int findDirection()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        if(angle >= 90 || angle <= -90)
        {
            return -1;
        }
        else if(angle < 90 || angle > -90  )
        {
            return 1;
        }
        return 0;
    }

}
