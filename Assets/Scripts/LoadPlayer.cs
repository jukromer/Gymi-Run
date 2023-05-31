using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadPlayer : MonoBehaviour
{
    public string targetName; // Das Tag des GameObjects, das Sie suchen möchten
    public Transform parentObject; // Das GameObject, dem das gesuchte GameObject als Child hinzugefügt werden soll

    void Start()
    {
        targetName = PlayerManager.CharacterName;
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
