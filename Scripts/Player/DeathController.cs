using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField]
    AudioSource death;
    [SerializeField]
    bool isFirstDeath;

    [SerializeField]
    GameObject gameOverScreen;

    [SerializeField]
    GameObject switchManager;

    private void Start()
    {
        switchManager = GameObject.FindWithTag("SwitchManager");
    }

    public void onDeath()
    {
        if (!isFirstDeath)
        {

            death.Play();
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 2, ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().freezeRotation = true;
            GetComponent<Collider2D>().isTrigger = true;


            if (GetComponent<BoundController>() != null)
            {


                GetComponent<BoundController>().enabled = false;

            }
            else
            {

                GetComponent<LeapController>().enabled = false;

            }
            isFirstDeath = true;

        }




    }

    public void displayGameOver()
    {
        
        switchManager.SetActive(false);
        gameOverScreen.SetActive(true);
        

    }
}
