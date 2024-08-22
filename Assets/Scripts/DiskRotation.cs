using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskRotation : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, 0, -mouseX);
    }
}