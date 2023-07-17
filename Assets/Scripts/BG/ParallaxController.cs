using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public Transform[] backgrounds;    // Die verschiedenen Hintergründe als Array von Transforms
    public float parallaxScale = 0.5f; // Die Geschwindigkeit, mit der sich die Hintergründe bewegen (0.5 bedeutet halbe Geschwindigkeit der Kamera)

    private Transform cameraTransform; // Referenz zur Transform-Komponente der Hauptkamera
    private Vector3 lastCameraPosition; // Die Position der Kamera im letzten Frame

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        // Die Differenz zwischen der aktuellen Kameraposition und der Position im letzten Frame berechnen
        float deltaX = cameraTransform.position.x - lastCameraPosition.x;

        // Die Hintergründe entsprechend der Parallax-Scale und der Kamerabewegung verschieben
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 backgroundTargetPosition = backgrounds[i].position;
            backgroundTargetPosition.x += deltaX * parallaxScale * (i + 1); // Geschwindigkeit abhängig von der Reihenfolge der Hintergründe
            backgrounds[i].position = backgroundTargetPosition;
        }

        // Die aktuelle Kameraposition für das nächste Frame speichern
        lastCameraPosition = cameraTransform.position;
    }
}

