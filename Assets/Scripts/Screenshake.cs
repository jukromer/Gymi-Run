using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    public float intensity = 0.1f;
    public float duration = 0.05f;
    
    private float shakeTimer = 0f;
    private Vector3 initialPosition;
    //[SerializeField] CameraController cameraController;
    
    void Start()
    {
        initialPosition = transform.position;
    }
    
    void Update()
    {
       ShakeLogic(); 
    }
    
    public void Shake()
    {
        // Start the screenshake effect
        shakeTimer = duration;
        print("shaked");
    }

    private void ShakeLogic()
    {
        if (shakeTimer > 0f)
        {
            initialPosition = transform.position;
            Vector3 shakeOffset = Random.insideUnitSphere * intensity;
            transform.position = initialPosition + shakeOffset;
            
            // Decrement the shake timer
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset the camera position to its initial position
            transform.position = initialPosition;
        }
    }
}

