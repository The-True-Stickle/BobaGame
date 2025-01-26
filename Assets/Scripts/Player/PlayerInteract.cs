using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    PlayerInput input;
    RaycastHit hit;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10f);
        if (Physics.Raycast(transform.position, transform.forward * 10f, out hit))
        { 
		    if (hit.transform.TryGetComponent(out BobaMachine bobaMachine))
            {
                Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
                if (Input.GetKeyDown(input.interactKey))
                {
                    BobaBotManager.instance.OpenBobaBotUI(bobaMachine);
                }
            }
		}
    }
}
