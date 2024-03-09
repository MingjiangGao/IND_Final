using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform Character;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
         Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
void Update()
{
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    // Rotate the player body horizontally first
    Character.Rotate(Vector3.up * mouseX);

    // Then rotate the camera vertically
    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    // Apply the vertical rotation to the camera
    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
}

}

