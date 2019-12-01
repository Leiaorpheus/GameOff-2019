using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    [SerializeField]
    protected bool hasFlipped;
    [SerializeField]
    protected Animator anim;
    [SerializeField]
    protected AudioSource switchSound;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasFlipped) {

            if(collision.gameObject.tag == "Player")
            {

                anim.SetTrigger("Switch");
                switchSound.Play();
            }

                
        }
    }

    public virtual void flip() {

        hasFlipped = true;

    }

    
}
