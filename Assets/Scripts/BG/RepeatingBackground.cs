using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public Transform[] backgrounds; // Die verschiedenen Hintergründe als Array von Transforms
    public Vector2 [] backgroundStartPositions;

    public Transform [] trees;
    public Vector2 [] treesStartsPosition;

    public Transform [] skys;
    public Vector2 [] skysStartsPosition;


    public float backgroundWidth = 34.16f; // Die Breite eines Hintergrundbildes
    public float offset = 20f; // Ein kleiner Versatz, um eventuelle Lücken zu vermeiden
    [SerializeField] PlayerMovement playerMovement;
    

    private Transform cameraTransform; // Referenz zur Transform-Komponente der Hauptkamera
    private float lastCameraX; // Die x-Position der Kamera im letzten Frame
    private float qZtrees;
    private float qZskys;

    private void Start()
    {
        qZtrees = Mathf.Abs(cameraTransform.position.x/trees[0].position.x);
        qZskys = Mathf.Abs(cameraTransform.position.x/skys[0].position.x);
        backgroundStartPositions = new Vector2[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgroundStartPositions[i] = backgrounds[i].position;
        }
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
    }

    private void Update()
    {
        if (playerMovement.getPlayerXvelo() >= 0)
        {
            scrollBGright();
        }
        else
        {
            scrollBGleft();
        }
        
    }

    public void resetBackground()
    {
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position = backgroundStartPositions[i];
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

    }
}

