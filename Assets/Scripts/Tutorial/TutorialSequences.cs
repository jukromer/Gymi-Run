using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialSequences : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject [] tables;
    [SerializeField] GameObject Player;
    [SerializeField] Transform playerTransform;
    [SerializeField] TutorialInstructions tutorialInstructions;
    [SerializeField] DeathScreenController deathScreenController;
    [SerializeField] PlayerMovement playerMovement;





    private bool IsSequence1 = false;
    private bool IsSequence2 = false;
    private bool IsSequence3 = false;
    private bool IsSequence4 = false;
    private bool IsSequence5 = false;
    
    
    

    void Start()
    {
        UI.SetActive(false);
        tables = GameObject.FindGameObjectsWithTag("Ground");
        for(int i = 4; i < tables.Length; i++)
        {
            deactivateTables(tables[i]);
        }
        Sequence1();    
    }

    void Update()
    {
        if(playerTransform.position.y <= -6f)
        {
            tutorialInstructions.printWarningMessage(tutorialInstructions.ImmortalMessage);
            deathScreenController.Respawn();
            StartCoroutine(ResetText());
        }
    }

    public void Sequence1()
    {
        bool walkedLeft = false;
        bool walkedRight = false;
        bool jumped = false;
        bool doubleJumped = false;
        bool stomped = false;
        bool airJumped = false;

        IsSequence1 = true;

        tutorialInstructions.printMessage(tutorialInstructions.WalkMessage);
        // tutorialInstructions.printMessage(tutorialInstructions.JumpMessage);
        // tutorialInstructions.printMessage(tutorialInstructions.DoubleJumpMessage);
        // tutorialInstructions.printMessage(tutorialInstructions.AirjumpMessage);
        // tutorialInstructions.printMessage(tutorialInstructions.StompMessage);

        while(IsSequence1)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jumped = true;
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                walkedLeft = true;
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                walkedRight = true;
            }
            if(Input.GetKeyDown(KeyCode.LeftShift) && !playerMovement.IsGrounded())
            {
                stomped = true;
            }
            if(Input.GetKeyDown(KeyCode.Space) && !playerMovement.IsGrounded() && playerMovement.getJumpCount() == 1)
            {
                doubleJumped = true;
            }
            if(Input.GetKeyDown(KeyCode.Space) && !playerMovement.IsGrounded() && playerMovement.getJumpCount() == 0)
            {
                airJumped = true;
            }
            if(walkedLeft && walkedRight && jumped && doubleJumped && stomped && airJumped)
            {
                IsSequence1 = false;
                Sequence2();
            }
        }
    }

    public void Sequence2()
    {
        
    }

    public void Sequence3()
    {
        
    }

    public void Sequence4()
    {
        
    }

    public void Sequence5()
    {
        
    }

    private IEnumerator ResetText()
    {
        yield return new WaitForSeconds(2f);
        tutorialInstructions.ResetText();
    }

    private void deactivateTables(GameObject table)
    {
        BoxCollider2D collider = table.GetComponent<BoxCollider2D>();
        collider.enabled = false;
        SpriteRenderer spriteRenderer = table.GetComponent<SpriteRenderer>();
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0.5f;
        spriteRenderer.color = spriteColor;
    }

    public void Deactivate(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void Activate(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
