using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapController : CharacterController
{

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.Move();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && SwitchCharacter.activeMember == gameObject)
        {
            rb2d.velocity = Vector2.zero;
            collision.rigidbody.bodyType = RigidbodyType2D.Static;
            Debug.Log("leap hits bound");
        }


        if (collision.gameObject.tag != "Ground") {

            isWalking = false;
        }
    }

    public void settingJump(bool val)
    {

        GetComponent<Jumping>().enabled = val;
        GetComponent<BetterJump>().enabled = val;

    }



}
