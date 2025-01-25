using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    PlayerInput input;
    public Camera cam;

    [SerializeField] float sensX;
    [SerializeField] float sensY;
    private float xRotation;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleLook();
    }

    private void HandleLook()
    { 
        xRotation -= input.mouseY * Time.deltaTime * sensY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, input.mouseX * sensX * Time.deltaTime, 0);
	}
        
}
