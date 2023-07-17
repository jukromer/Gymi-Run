using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public Transform[] backgrounds; // Die verschiedenen Hintergründe als Array von Transforms
    private Transform [] backgroundsSave;
    public Vector2 [] backgroundStartPositions;
    public float backgroundWidth = 34.16f; // Die Breite eines Hintergrundbildes
    public float offset = 20f; // Ein kleiner Versatz, um eventuelle Lücken zu vermeiden

    private Transform cameraTransform; // Referenz zur Transform-Komponente der Hauptkamera
    private float lastCameraX; // Die x-Position der Kamera im letzten Frame

    private void Start()
    {
        backgroundsSave = backgrounds;
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
        float deltaX = cameraTransform.position.x - lastCameraX;

        // Überprüfe, ob ein Hintergrundbild das Sichtfeld der Kamera verlassen hat
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

    public void resetBackground()
    {
        backgrounds = backgroundsSave;
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position = backgroundStartPositions[i];
        }
    }
}

