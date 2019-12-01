using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    bool isFirstHit = true;
    public bool isDead = false;
    [SerializeField]
    GameObject laser;
    [SerializeField]
    AudioSource deathBeep;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFirstHit)
        {
            if((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Turret") && !isDead)
            {

                laser.SetActive(false);
                deathBeep.Play();
                GetComponent<Animator>().SetTrigger("Dead");
                gameObject.layer = LayerMask.NameToLayer("Ground");
                isFirstHit = false;
            }
           

        }
    }
}
