using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;
        if (Mouse.current != null)
        {
            mouseX = Mouse.current.delta.ReadValue().x * mouseSensitivity;
            mouseY = Mouse.current.delta.ReadValue().y * mouseSensitivity;
        }
        if (Gamepad.current != null)
        {
            mouseX = Gamepad.current.rightStick.ReadValue().x * mouseSensitivity;
            mouseY = Gamepad.current.rightStick.ReadValue().y * mouseSensitivity;
        }
        xRotation += mouseY * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80, 80);
        transform.localRotation = Quaternion.Euler(-xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }
}
