using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InstructionManager : MonoBehaviour
{
    [TextArea(5, 5)]
    public string leapInstruction, boundInstruction;
   
    void showLeapText()
    {

        GetComponent<TextMeshPro>().text = leapInstruction;

    }


    void showBoundText() {

        GetComponent<TextMeshPro>().text = boundInstruction;

    }


    public void showCorrospondingText()
    {
        // if it is leap
        if(SwitchCharacter.activeMember.GetComponent<LeapController>())
        {
            showLeapText();


        }
        else
        {
            // else it is bound

            showBoundText();

        }

    }

}
