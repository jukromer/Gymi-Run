using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] GameObject [] foreGround;
    [SerializeField] GameObject [] midGround;
    [SerializeField] GameObject [] Background;

    private void Start() 
    {
        
    }

    void Update()
    {
        checkCameraVisibility visibilityChecker = foreGround[0].GetComponent<checkCameraVisibility>();
            if(!visibilityChecker.IsVisibleOnScreen())
            {
                GameObject element = foreGround[0];
                element.transform.position = new Vector2(foreGround[foreGround.Length].transform.position.x + 34.16f, 5.01f);
                for(int i = 1; i < foreGround.Length; i++)
                {
                    foreGround[i - 1] = foreGround[i];
                }
                foreGround[foreGround.Length] = element;
            }
    }

}
