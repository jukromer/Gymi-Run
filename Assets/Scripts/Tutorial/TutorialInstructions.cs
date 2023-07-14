using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialInstructions : MonoBehaviour
{
    public string ImmortalMessage;
    public string WalkMessage;
    public string JumpMessage;
    public string DoubleJumpMessage;
    public string AirjumpMessage;
    public string StompMessage;




    private string Jump;
    private string walkRight;
    private string walkLeft;
    private string doubleJump;
    private string airJump;
    private string stomp;


    [SerializeField] TMP_Text Warnings;
    [SerializeField] TMP_Text [] Instructions = new TMP_Text [20];
    [SerializeField] TMP_Text Instruction;
    [SerializeField] int InstructionCount;
    private RectTransform previousInstruction;


    void Start()
    {
        ResetText();
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
        WalkMessage = "Laufe mit A/D nach links/rechts";
    }

    public void printMessage(string Message)
    {
        if(InstructionCount == 0)
        {
            print("Test1" + InstructionCount);
            Instructions[InstructionCount] = Instantiate(Instruction, new Vector2(152f, -31), Quaternion.identity);
            Instructions[InstructionCount].text = Message;
            previousInstruction = Instructions[InstructionCount].GetComponent<RectTransform>();
            InstructionCount++;
        }
        else
        {
            print("Test2" + InstructionCount);
            Instructions[InstructionCount] = Instantiate(Instruction, new Vector2(previousInstruction.anchoredPosition.x, previousInstruction.anchoredPosition.y - 10f), Quaternion.identity);
            Instructions[InstructionCount].text = Message;
            previousInstruction = Instructions[InstructionCount].GetComponent<RectTransform>();
            InstructionCount++;
        }        
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



}
