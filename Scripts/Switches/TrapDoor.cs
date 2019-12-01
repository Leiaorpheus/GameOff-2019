using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public bool isSwitchedOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isSwitchedOff) {


            GetComponent<Animator>().SetTrigger("Stepped");

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isSwitchedOff)
        {


            GetComponent<Animator>().SetTrigger("Stepped");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            GetComponent<Animator>().ResetTrigger("Stepped");

        }
    }
}
