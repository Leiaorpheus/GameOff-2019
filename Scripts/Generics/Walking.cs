using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2d;
    public static float moveInput;

    [SerializeField]
    bool faceRight = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Walk();
    }

    // script to make character walk
   void Walk()
   {
        moveInput = Input.GetAxis("Horizontal");
        Vector2 speedVect = new Vector2(moveInput * speed, rb2d.velocity.y);
        rb2d.velocity = speedVect;
        Flip();
   }
    
   void Flip()
    {
        if (moveInput > 0 && !faceRight)
            faceRight = true;

        else if (moveInput < 0 && faceRight)
            faceRight = false;
    }
    
    
}
