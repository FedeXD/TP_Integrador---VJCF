using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorRotarCamara : MonoBehaviour
{
    public float sensitivity = 2.0f;
    private float rotX;
    private float rotY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotX += mouseY;
        rotY += mouseX;
        rotX = Mathf.Clamp(rotX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotX, rotY, 0);
    }
}
