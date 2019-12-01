using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textInfo;
    [SerializeField]
    bool canRestart;

    private void OnEnable()
    {
        Invoke("toStart", 1.0f);
    }
   

    // Update is called once per frame
    void Update()
    {
        if (canRestart)
        {

            if (Input.anyKey)
            {

                Scene scene = SceneManager.GetActiveScene();
                int index = scene.buildIndex;
                if(index != SceneManager.sceneCountInBuildSettings - 1)
                    SceneManager.LoadScene(scene.name);
                else
                    SceneManager.LoadScene("Tutorial");
            }

        }
    }

    void toStart()
    {

        textInfo.enabled = true;
        canRestart = true;
    }
}
