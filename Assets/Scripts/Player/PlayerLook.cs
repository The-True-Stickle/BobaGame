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
        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        //Waits till after the bobaBotManager has been initialized
        yield return new WaitForSeconds(0.1f);
        BobaBotManager.instance.playerLook = this;
    }

    public void toggleMouseInput(bool toggle)
    {
        if (toggle)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Update()
    {
        if (!BobaBotManager.instance.menuOpen)
        {
            HandleLook();

        }
    }

    private void HandleLook()
    { 
        xRotation -= input.mouseY * Time.deltaTime * sensY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, input.mouseX * sensX * Time.deltaTime, 0);
	}
        
}
