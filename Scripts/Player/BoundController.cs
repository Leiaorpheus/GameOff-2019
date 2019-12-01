using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : CharacterController
{
    [SerializeField]
    bool canMove;

    [SerializeField]
    Vector3 currentLocation;

    [SerializeField]
    float moveTimer, timerCopy, maxSpeed = 20, originalSpeed, speedIncrement = 0.5f;

    protected override void Start()
    {
        canMove = true;
        timerCopy = moveTimer;
        originalSpeed = speed;
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove) currentLocation = transform.position;
        Accelate();

        
    }


    void Accelate()
    {
        if (Input.GetButton(inputName) && canMove)
        {

            float dir = Input.GetAxis(inputName);

            /*
            if(speed < maxSpeed)
            {
                speed += Time.deltaTime;
            }
            */
            
            Vector2 direction = new Vector2 (dir * speed, rb2d.velocity.y);
            //rb2d.velocity = new Vector2(dir * speed, rb2d.velocity.y);
            rb2d.AddForce(direction * speed * Time.fixedDeltaTime);

            if (Vector3.Distance(currentLocation, transform.position) >= 30f) canMove = false;

        }

       // if button is lifted up, then can move
        if(Input.GetButtonUp(inputName))
        {
            canMove = true;
        }

        if (rb2d.velocity != Vector2.zero)
        {
            GetComponent<Animator>().SetBool("Roll", true);

        } else
        {

            GetComponent<Animator>().SetBool("Roll", false);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Ground")
        {
            if(rb2d.bodyType != RigidbodyType2D.Static)
            {

                rb2d.velocity = Vector2.zero;
                Vector3 force = transform.position - collision.transform.position;

                force.Normalize();
                GetComponent<Rigidbody2D>().AddForce(-force * speed);


            }
           

            if (collision.gameObject.tag == "Player" && SwitchCharacter.activeMember == gameObject)
            {
                rb2d.velocity = Vector2.zero;
                collision.rigidbody.bodyType = RigidbodyType2D.Static;
            }
        }

      
    }


    public void disableRoll()
    {

        rb2d.freezeRotation = true;

    }

    public void enableRoll()
    {

        rb2d.freezeRotation = false;

    }
    /*
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Ground")
        {
            speed = originalSpeed;
        }
    }*/

}
