using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadPlayer : MonoBehaviour
{
    public string targetName; 
    public Transform parentObject;
    [SerializeField] bool DevMode = false;
    public TMP_Text DevModeMessage;

    void Start()
    {
        DevModeMessage.text = "";
        if(DevMode)
        {
            targetName = "PascalCut";
            DevModeMessage.text = "DevMode is activated! <Pascal> will always automatically be chosen as the played character. Deactivate DevMode in Player --> LoadPlayer --> DevMode.";
        }
        else
        {
            targetName = PlayerManager.CharacterName;   
        }
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("PlayerSprite");
        for(int i = 0; i < objectsWithTag.Length; i++)
        {
            if(objectsWithTag[i].name != targetName)
            {
                objectsWithTag[i].SetActive(false);
            }
            else
            {
                objectsWithTag[i].SetActive(true);
                objectsWithTag[i].transform.SetParent(parentObject);
            }
        }

    }
}
