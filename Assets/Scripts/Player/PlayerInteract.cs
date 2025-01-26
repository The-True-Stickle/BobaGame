using System;
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

                    if (bobaMachine.drinkInMachine)
                    {
                        Debug.Log("There is already a drink in the machine");
                        if(GetComponent<PlayerAttack>().currentBobaInCup > 0)
                        {
                            Debug.Log("Your hands are full");
                        }
                        else
                        {
                            GetComponent<PlayerAttack>().HandleSwitchDrink(bobaMachine.currentBobaType);
                            GetComponent<PlayerAttack>().GetNewCup();
                            bobaMachine.drinkTaken();

                        }
                        return;
                    }

                    BobaBotManager.instance.OpenBobaBotUI(bobaMachine);
                }
            }
            else if (hit.transform.TryGetComponent(out RegisterStuff cashRegister))
            {
                Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
                if (Input.GetKeyDown(input.interactKey))
                {
                    PlayerAttack playerAttack = GetComponent<PlayerAttack>();

                    if (playerAttack.bobaFresh)
                    {
                        cashRegister.ServeDrink(playerAttack.currentBobaType);
                        playerAttack.bobaFresh = false;
                        playerAttack.currentBobaInCup = 0;
                        playerAttack.updateImage(null);

                    }
                    else
                    {
                        Debug.Log("That's not servable!!");
                    }

                }
            }
		}
    }
}
