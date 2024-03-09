using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript_B : MonoBehaviour
{
    public float cameraSensitivity = 100f;
    public Transform characterBody;
    float xRotation = 0f;
    float yRotation = 0f;

    void Update()
    {
        // Camera rotation amount based on sensitivity and time
        float cameraRotationAmount = cameraSensitivity * Time.deltaTime;

        // Get input from the keyboard
        if (Input.GetKey(KeyCode.I)) {
            // Look up
            xRotation -= cameraRotationAmount;
            Debug.Log("Up");
        }
        if (Input.GetKey(KeyCode.K)) {
            // Look down
            xRotation += cameraRotationAmount;
            Debug.Log("Down");
        }
        if (Input.GetKey(KeyCode.J)) {
            // Look left
            yRotation -= cameraRotationAmount;
        }
        if (Input.GetKey(KeyCode.L)) { 
            // Look right
            yRotation += cameraRotationAmount;
        }

        // Clamp the X rotation to prevent flipping at the extremes
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Apply the horizontal rotation to the character (or the camera if you do not have a character body element)
        if (characterBody != null) {
            characterBody.Rotate(Vector3.up * yRotation);
        } else {
            transform.Rotate(Vector3.up * yRotation);
        }

        // Reset the yRotation to prevent compounding rotations
        yRotation = 0;
    }
}


