using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchCharacter : MonoBehaviour
{
    [SerializeField]
    GameObject leap, bound;

    [SerializeField]
    GameObject leapCamera, boundCamera;


    [SerializeField]
    GameEvent resetInstruction;
    public static GameObject activeMember;

    [SerializeField]
    AudioSource swapSound;

    private void Start()
    {
        activeMember = leap;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(activeMember == leap)
            {
                leap.GetComponent<LeapController>().textAttached.SetActive(false);
                leap.GetComponent<LeapController>().settingJump(false);
                leap.GetComponent<LeapController>().enabled = false;
                
                leapCamera.SetActive(false);
                boundCamera.SetActive(true);
                activeMember = bound;

                bound.GetComponent<BoundController>().textAttached.SetActive(true);
                bound.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                bound.GetComponent<BoundController>().enabled = true;
                Debug.Log(leap.GetComponent<Jumping>().enabled);


            }
            else
            {   
                leap.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                leap.GetComponent<LeapController>().enabled = true;
                leap.GetComponent<LeapController>().textAttached.SetActive(true);
                leap.GetComponent<LeapController>().settingJump(true);
                leapCamera.SetActive(true);
                boundCamera.SetActive(false);
                activeMember = leap;
                bound.GetComponent<BoundController>().textAttached.SetActive(false);
                bound.GetComponent<BoundController>().enabled = false;

            }

            swapSound.Play();
            resetInstruction.Raise();
        }
        
    }
}
