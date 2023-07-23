using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialSequences : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject [] UIObjects;
    [SerializeField] GameObject [] tables;
    [SerializeField] GameObject Player;
    [SerializeField] Transform playerTransform;
    [SerializeField] TutorialInstructions tutorialInstructions;
    [SerializeField] DeathScreenController deathScreenController;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject ArrowDown;
    [SerializeField] GameObject AbfrageInfo;
    [SerializeField] GameObject BuchInfo;
    [SerializeField] GameObject NoteInfo;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject Coin;
    [SerializeField] BossTrigger bossTrigger;




    //Sequences
    [SerializeField] bool IsSequence1 = false;
    [SerializeField] bool IsSequence2 = false;
    [SerializeField] bool IsSequence3 = false;
    [SerializeField] bool IsSequence4 = false;
    [SerializeField] bool IsSequence5 = false;

    //Achievements
    bool walkedLeft = false;
    private bool walkedRight = false;
    bool jumped = false;
    bool doubleJumped = false;
    bool stomped = false;
    bool airJumped = false;
    bool printed = false;
    bool bossTriggered = false;
    
    
    

    void Start()
    { 
        BuchInfo.SetActive(false);
        NoteInfo.SetActive(false);
        Deactivate(Coin);
        int childCount = UI.transform.childCount;
        UIObjects = new GameObject[childCount];
        for(int a = 0; a < UIObjects.Length; a++)
        {
            UIObjects[a] = UI.transform.GetChild(a).gameObject;
            UIObjects[a].SetActive(false);
        }
        // tables = GameObject.FindGameObjectsWithTag("Ground");
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
            if (IsSequence1)
            {
                tutorialInstructions.printWarningMessage(tutorialInstructions.ImmortalMessage);
            }
            int amount = playerController.getPlayerCoinCount();
            bool bossState = bossTrigger.getBossSpawnState();
            deathScreenController.Respawn();
            bossTrigger.setBossSpawnState(bossState);
            playerController.setPlayerCoinCount(amount);
            if (bossTrigger.getBossSpawnState())
            {
                bossTrigger.spawnBoss();
            }
            StartCoroutine(tutorialInstructions.ResetWarning());

        }

        if(IsSequence1)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jumped = true;
                tutorialInstructions.checkInstruction(1);
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                walkedLeft = true;
                tutorialInstructions.checkInstruction(0);
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                walkedRight = true;
                tutorialInstructions.checkInstruction(0);
            }
            if(Input.GetKeyDown(KeyCode.LeftShift) && !playerMovement.IsGrounded())
            {
                stomped = true;
                tutorialInstructions.checkInstruction(4);
            }
            if(Input.GetKeyDown(KeyCode.Space) && !playerMovement.IsGrounded() && playerMovement.getJumpCount() == 1)
            {
                doubleJumped = true;
                tutorialInstructions.checkInstruction(2);
            }
            if(Input.GetKeyDown(KeyCode.Space) && !playerMovement.IsGrounded() && playerMovement.getJumpCount() == 0)
            {
                airJumped = true;
                tutorialInstructions.checkInstruction(3);
            }
            if(walkedLeft && walkedRight && jumped && doubleJumped && stomped && airJumped)
            {
                IsSequence1 = false;
                Sequence2();
            }
        }
        if(IsSequence2)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                tutorialInstructions.checkInstruction(2);
                IsSequence2 = false;
                Sequence3();
            }
        }
        if(IsSequence3)
        {
            BuchInfo.SetActive(true);
            if(playerController.getPlayerCoinCount() == 10 && !printed)
            {
                printed = true;
                tutorialInstructions.printSequence3();
            }
            if(Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.B))
            {
                IsSequence3 = false;
                Sequence4();
            }
        }
        if(IsSequence4)
        {
            if(bossTrigger.getBossSpawnState() == true && bossTriggered == false)
            {
                bossTriggered = true;
                tutorialInstructions.printSequence4();
            }
        }
    }

    public void Sequence1()
    {
        toggleAbfrageInfo(false);
        toggleArrowDown(false);
        IsSequence1 = true;

        tutorialInstructions.printSequence1();
    }

    public void Sequence2()
    {
        for(int a = 1; a < 4; a++)
        {
            UIObjects[a].SetActive(true);
        }
        IsSequence2 = true;
        toggleAbfrageInfo(true);
        toggleArrowDown(true);
        tutorialInstructions.printWarningMessage("Du kannst Schaden bekommen");
        StartCoroutine(tutorialInstructions.ResetWarning());
        tutorialInstructions.printSequence2();
        for(int i = 0; i < 9; i++)
        {
            activateTables(tables[i]);
        }
    }

    public void Sequence3()
    {
        toggleArrowDown(false);
        BuchInfo.SetActive(true);
        IsSequence3 = true;
        ArrowDown.transform.position = new Vector2(39f, 2.9f);
        toggleAbfrageInfo(false);
        playerController.setPlayerCoinCount(9);
        for(int i = 0; i < 7; i++)
        {
            UIObjects[i].SetActive(true);
        }
        Activate(Coin);
        activateTables(tables[9]);
    }

    public void Sequence4()
    {
        BuchInfo.SetActive(false);
        NoteInfo.SetActive(true);
        IsSequence4 = true;
        for (int i = 0; i < tables.Length; i++)
        {
            activateTables(tables[i]);
        }
    }

    private IEnumerator ResetText()
    {
        yield return new WaitForSeconds(2f);
        tutorialInstructions.ResetAllText();
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

    private void activateTables(GameObject table)
    {
        BoxCollider2D collider = table.GetComponent<BoxCollider2D>();
        collider.enabled = true;
        SpriteRenderer spriteRenderer = table.GetComponent<SpriteRenderer>();
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 1f;
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

    private void toggleArrowDown(bool state)
    {
        ArrowDown.SetActive(state);
    }

    private void toggleAbfrageInfo(bool state)
    {
        AbfrageInfo.SetActive(state);
    }
}
