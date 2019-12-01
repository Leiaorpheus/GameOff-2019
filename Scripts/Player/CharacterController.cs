using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, IControl
{
    [SerializeField]
    protected float speed;

    [SerializeField]
    protected string inputName;

    [SerializeField]
    protected Rigidbody2D rb2d;

    [SerializeField]
    protected bool isWalking;

    [SerializeField]
    protected AudioSource movementSound;

    public bool isDead;
    public GameObject textAttached;
    
     protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public virtual void Move()
    {
        GetComponent<Animator>().SetBool("isWalking", Input.GetButton(inputName));
        float dir =  Input.GetAxis(inputName);

        rb2d.velocity = new Vector2(dir * speed, rb2d.velocity.y);

        bool isWalking = (dir != 0) ? true : false;
        
        GetComponent<Animator>().SetFloat("WalkX", dir);

    }


    public virtual void playMovementSound()
    {
        movementSound.Play();

    }

    public virtual void disableText()
    {

        textAttached.SetActive(false);
    }

}
