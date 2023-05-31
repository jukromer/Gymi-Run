using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadPlayer : MonoBehaviour
{
    public string targetTag; // Das Tag des GameObjects, das Sie suchen möchten
    public Transform parentObject; // Das GameObject, dem das gesuchte GameObject als Child hinzugefügt werden soll
    private PlayerMovement playerMovement;
    private Animator playerAnimator;

    void Start()
    {
        targetTag = PlayerManager.CharacterName;
        Debug.Log(targetTag);
        playerMovement = GetComponent<PlayerMovement>();
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

        if (objectsWithTag.Length > 0)
        {
            GameObject targetObject = objectsWithTag[0];
            targetObject.SetActive(true);
            targetObject.transform.SetParent(parentObject);
        }
        else
        {
            Debug.LogError("No GameObject found with the tag: " + targetTag);
        }
    }
}
