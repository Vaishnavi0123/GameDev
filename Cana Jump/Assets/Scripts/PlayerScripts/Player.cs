using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour 
{
   
    public float speed = 8f, maxVelocity = 4f;
 
    private Rigidbody2D myBody;
    private Animator anim;
 
 
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
 
    }
 
    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }
 
 
    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
 
        float h = Input.GetAxisRaw("Horizontal");
 
        if(h > 0)
        {
            if(vel < maxVelocity)
            forceX = speed;
 
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;
 
            anim.SetBool("walk", true);
        }
        else if(h < 0)
        {
            if(vel < maxVelocity)
            forceX = -speed;
 
            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;
 
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        myBody.AddForce(new Vector2(forceX, 0));
    }
}
    