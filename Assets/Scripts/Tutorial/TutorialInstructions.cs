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

    public void ResetAllText()
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
        for(int i = 0; i < Instructions.Length; i++)
        {
            Instructions[i].gameObject.SetActive(true);
            ResetText(i);
        }
        printMessage("Drücke P", 2);
    }

    public void printSequence3()
    {
        for(int i = 0; i < Instructions.Length; i++)
        {
            Instructions[i].gameObject.SetActive(true);
            ResetText(i);
        }
        printMessage("Du hast 10 Bücher, wähle eines der PowerUps", 0);
        printMessage("Drücke H um ein Herz zurückzubekommen", 1);
        printMessage("Drücke B um für 10s von einer Schutzblase umgeben zu sein", 2);
        // for(int a = 0; a < 3; a++)
        // {
        //     Instructions[a].gameObject.transform.position = new Vector2(1100f, Instructions[a].gameObject.transform.position.y);
        // }
    }

    public void printSequence4()
    {
        for(int i = 0; i < Instructions.Length; i++)
        {
            Instructions[i].gameObject.SetActive(true);
            ResetText(i);
        }
        printMessage("Der Boss wurde gespawnt!", 1);
        printMessage("Du kannst ihn nur besiegen, indem du das Ende des Levels erreichst", 2);
    }

    public void checkInstruction(int Index)
    {
        Instructions[Index].gameObject.SetActive(false);
    }

    public void ResetText(int Index)
    {
        Instructions[Index].text = "";
    }
}

