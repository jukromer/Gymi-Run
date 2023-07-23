using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public Transform[] backgrounds; // Die verschiedenen Hintergründe als Array von Transforms
    public Vector2 [] backgroundStartPositions;

    [SerializeField] ParallaxController parallaxController;
    public Vector2 [] treesStartPositions;
    public Vector2 [] skysStartsPosition;


    public float backgroundWidth = 34.16f; // Die Breite eines Hintergrundbildes
    public float treeWidth = 18.5f;
    public float skyWidth = 34.16f;
    public float houseWidth = 7f;
    public float offset = 20f; // Ein kleiner Versatz, um eventuelle Lücken zu vermeiden

    
    [SerializeField] PlayerMovement playerMovement;
    

    private Transform cameraTransform; // Referenz zur Transform-Komponente der Hauptkamera
    private float lastCameraX; // Die x-Position der Kamera im letzten Frame
    

    private void Start()
    {
        backgroundStartPositions = new Vector2[backgrounds.Length];
        treesStartPositions = new Vector2[parallaxController.trees.Length];
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgroundStartPositions[i] = backgrounds[i].position;
        }
        for(int i = 0; i < parallaxController.trees.Length; i++)
        {
            treesStartPositions[i] = parallaxController.trees[i].position; 
        }
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
    }

    private void Update()
    {
        if (playerMovement.getPlayerXvelo() >= 0)
        {
            scrollBGright();
            scrollTreesRight();
            //scrollSkyRight();
            //scrollHouseRight();
        }
        else
        {
            scrollBGleft();
            scrollTreesLeft();
            //scrollSkyLeft();
            //scrollHouseLeft();
        }
        
    }

    public void resetBackground()
    {
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position = backgroundStartPositions[i];
        }
    }

    public void resetTrees()
    {
       for(int i = 0; i < parallaxController.trees.Length; i++)
        {
            parallaxController.trees[i].position = treesStartPositions[i];
        } 
    }

    private void scrollBGright()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (cameraTransform.position.x > backgrounds[i].position.x + backgroundWidth * 0.5f + offset)
            {
                // Verschiebe das Bild nach hinten, sodass es sich wiederholt
                Vector3 backgroundTargetPosition = backgrounds[i].position;
                backgroundTargetPosition.x += backgroundWidth * backgrounds.Length;
                backgrounds[i].position = backgroundTargetPosition;
            }
        }

        lastCameraX = cameraTransform.position.x;
    }

    private void scrollBGleft()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (cameraTransform.position.x < backgrounds[i].position.x - backgroundWidth * 0.5f - offset)
            {
                // Verschiebe das Bild nach hinten, sodass es sich wiederholt
                Vector3 backgroundTargetPosition = backgrounds[i].position;
                backgroundTargetPosition.x -= backgroundWidth * backgrounds.Length;
                backgrounds[i].position = backgroundTargetPosition;
            }
        }

        lastCameraX = cameraTransform.position.x;
    }

    private void scrollTreesRight()
    {
        for (int i = 0; i < parallaxController.trees.Length; i++)
        {
            if(cameraTransform.position.x > parallaxController.trees[i].position.x + treeWidth * 0.5f + offset)
            {
                Vector3 treeTargetPosition = parallaxController.trees[i].position;
                treeTargetPosition.x += treeWidth * parallaxController.trees.Length;
                parallaxController.treePositions[i] = new Vector3(treeTargetPosition.x, parallaxController.treePositions[i].y, parallaxController.treePositions[i].z); 
                parallaxController.trees[i].position = treeTargetPosition;
            }
        }
    }

    private void scrollTreesLeft()
    {
        for (int i = 0; i < parallaxController.trees.Length; i++)
        {
            if(cameraTransform.position.x < parallaxController.trees[i].position.x - treeWidth * 0.5f - offset)
            {
                Vector3 treeTargetPosition = parallaxController.trees[i].position;
                treeTargetPosition.x -= treeWidth * parallaxController.trees.Length;
                parallaxController.treePositions[i] = new Vector3(treeTargetPosition.x, parallaxController.treePositions[i].y, parallaxController.treePositions[i].z); 
                parallaxController.trees[i].position = treeTargetPosition;
            }
        }
    }

    private void scrollSkyRight()
    {
        for (int i = 0; i < parallaxController.skys.Length; i++)
        {
            if(cameraTransform.position.x > parallaxController.skys[i].position.x + skyWidth * 0.5f + offset)
            {
                Vector3 skyTargetPosition = parallaxController.skys[i].position;
                skyTargetPosition.x += skyWidth * parallaxController.skys.Length;
                parallaxController.skyPositions[i] = new Vector3(skyTargetPosition.x, parallaxController.skyPositions[i].y, parallaxController.skyPositions[i].z); 
                parallaxController.skys[i].position = skyTargetPosition;
            }
        }
    }

    private void scrollSkyLeft()
    {
        for (int i = 0; i < parallaxController.skys.Length; i++)
        {
            if(cameraTransform.position.x < parallaxController.skys[i].position.x - skyWidth * 0.5f - offset)
            {
                Vector3 skyTargetPosition = parallaxController.skys[i].position;
                skyTargetPosition.x -= skyWidth * parallaxController.skys.Length;
                parallaxController.skyPositions[i] = new Vector3(skyTargetPosition.x, parallaxController.skyPositions[i].y, parallaxController.skyPositions[i].z); 
                parallaxController.skys[i].position = skyTargetPosition;
            }
        }
    }

    private void scrollHouseRight()
    {
        for (int i = 0; i < parallaxController.houses.Length; i++)
        {
            if(cameraTransform.position.x > parallaxController.houses[i].position.x + houseWidth * 0.5f + offset * 2f)
            {
                Vector3 houseTargetPosition = parallaxController.houses[i].position;
                houseTargetPosition.x += houseWidth * parallaxController.houses.Length;
                parallaxController.housePositions[i] = new Vector3(houseTargetPosition.x, parallaxController.housePositions[i].y, parallaxController.housePositions[i].z); 
                parallaxController.houses[i].position = houseTargetPosition;
            }
        }
    }

    private void scrollHouseLeft()
    {
        for (int i = 0; i < parallaxController.houses.Length; i++)
        {
            if(cameraTransform.position.x < parallaxController.houses[i].position.x - houseWidth * 0.5f - offset * 2f)
            {
                Vector3 houseTargetPosition = parallaxController.houses[i].position;
                houseTargetPosition.x -= houseWidth * parallaxController.houses.Length;
                parallaxController.housePositions[i] = new Vector3(houseTargetPosition.x, parallaxController.housePositions[i].y, parallaxController.housePositions[i].z); 
                parallaxController.houses[i].position = houseTargetPosition;
            }
        }
    }
}

