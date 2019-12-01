using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField]
    GameObject particle;

    [SerializeField]
    AudioSource destroySound;

    [SerializeField]
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.GetComponent<BoundController>() != null || collision.gameObject.tag == "Turret") {

            destroySound.Play();
            GetComponent<BoxCollider2D>().enabled = false;
            sprite.enabled = false;
            Instantiate(particle, transform.position, Quaternion.identity);
            destroy();

        }
    }

    void destroy()
    {
        Destroy(gameObject, 1.0f);
    }
}
