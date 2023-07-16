using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialInstructions : MonoBehaviour
{
    //Messages
    public string ImmortalMessage;
    public string WalkMessage;
    public string JumpMessage;
    public string DoubleJumpMessage;
    public string AirjumpMessage;
    public string StompMessage;

    [SerializeField] TMP_Text Warnings;
    public TMP_Text [] Instructions;


    void Start()
    {
        WalkMessage = "Laufe mit A/D nach links/rechts";
        // ResetText();
        setImmortalMessage();
        setWalkMessage();
    }

    public void setImmortalMessage()
    {
        ImmortalMessage = "Du kannst aktuell noch nicht sterben";
    }

    public void printWarningMessage(string Warning)
    {
        Warnings.text = Warning;
    }

    public void setWalkMessage()
    {
        // WalkMessage = "Laufe mit A/D nach links/rechts";
    }

    public string getWalkMessage()
    {
        return WalkMessage;
    }

    public void printMessage(string Message, int Index)
    {
        print(Message + Index);
        Instructions[Index].text = Message;
        print(Instructions[Index].text);
    }

    public void ResetText()
    {
        for (int i = 0; i < Instructions.Length; i++)
        {
            if (Instructions[i] != null)
            {
                Instructions[i].text = "";
            }
        }
        Warnings.text = "";
    }

    public IEnumerator ResetWarning()
    {
        yield return new WaitForSeconds(2f);
        Warnings.text = "";
    }

    public void printSequence1()
    {
        printMessage("Laufe mit A/D nach links/rechts", 0);
        printMessage("Springe mit der Leertaste", 1);
        printMessage("Führe einen DoubleJump aus", 2);
        printMessage("Führe einen Airjump aus", 3);
        printMessage("Nutze shift um zu stompen", 4);
    }

    public void printSequence2()
    {
        printMessage("Drücke P", 2);
    }

    public void checkInstruction(int Index)
    {
        Instructions[Index].gameObject.SetActive(false);
    }
}

