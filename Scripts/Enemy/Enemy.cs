using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            if (!collision.GetComponent<CharacterController>().isDead) {
                collision.GetComponent<CharacterController>().isDead = true;
                collision.attachedRigidbody.velocity = Vector2.zero;
                collision.GetComponent<Animator>().SetBool("Dead", true);
            }
           

        }
    }
}
