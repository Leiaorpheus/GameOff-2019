using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    [SerializeField]
    GameObject textMeshTxt;
    [SerializeField]
    bool isLeap, isBound;
    string defaultReply;

    private void Start()
    {
        defaultReply = textMeshTxt.GetComponent<TextMeshPro>().text;
    }


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LeapController>())
        {
            isLeap = true;

        }
        else if (collision.gameObject.GetComponent<BoundController>())
        {

            isBound = true;
        }


        if (isLeap && isBound)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (isLeap)
        {
            textMeshTxt.GetComponent<TextMeshPro>().text = "Need Bound as well...";
        }

        else if (isBound)
        {
            textMeshTxt.GetComponent<TextMeshPro>().text = "Need Leap as well...";

        }
        else
        {
            textMeshTxt.GetComponent<TextMeshPro>().text = defaultReply;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LeapController>())
        {
            isLeap = false;

        }
        else if (collision.gameObject.GetComponent<BoundController>())
        {

            isBound = false;
        }
    }


}
