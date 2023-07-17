using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCameraVisibility : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Renderer objectRenderer;

    private void Start() 
    {
        mainCamera = Camera.main;
        objectRenderer = GetComponent<Renderer>();
    }
    
    public bool IsVisibleOnScreen()
    {
        // Erzeuge eine Bounds-Struktur basierend auf den Abmessungen des GameObjects
        Bounds objectBounds = objectRenderer.bounds;

        // Überprüfe, ob die AABB (Axis-Aligned Bounding Box) des GameObjects im Sichtfeld der Kamera liegt
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(mainCamera), objectBounds);
    }
}
