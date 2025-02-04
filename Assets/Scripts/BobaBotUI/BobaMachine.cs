using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaMachine : MonoBehaviour
{

    public bool currentlyMakingDrink = false;

    [SerializeField]
    private List<GameObject> drinks = new List<GameObject>();

    public bool drinkInMachine = false;
    public BobaType currentBobaType;

    private void Start()
    {
        Debug.Log("Boba Machine Started");
    }

    public void OpenBobaUI()
    {
        if (currentlyMakingDrink)
        {
            Debug.Log("Currently making a drink, cannot make another");
            return;
        }
        BobaBotManager.instance.OpenBobaBotUI(this);


    }

    public void MakeBoba(BobaType bobaType)
    {
        Debug.Log("Making Boba of type: " + bobaType.name);

        StartCoroutine(MakeBobaRoutine(bobaType));
        BobaBotManager.instance.CloseBobaBotUI();
    }

    private IEnumerator MakeBobaRoutine(BobaType bobaType)
    {
        currentlyMakingDrink = true;
        AudioManager.Instance.PlaySource(AudioSourceType.MachineWorking);
        yield return new WaitForSeconds(bobaType.bobaWaitTime);
        AudioManager.Instance.StopSource(AudioSourceType.MachineWorking);
        currentBobaType = bobaType;
        Debug.Log("Boba is ready");

        switch(bobaType.bobaName)
        {
            case "Milk Tea":
                drinks[0].SetActive(true);
                break;
            case "Matcha Tea":
                drinks[1].SetActive(true);
                break;
            case "Strawberry Tea":
                drinks[2].SetActive(true);
                break;
        }
        drinkInMachine = true;
        currentlyMakingDrink = false;
    }

    public void DrinkTaken()
    {
        drinkInMachine = false;
        for (int i = 0; i < drinks.Count; i++)
        {
            drinks[i].SetActive(false);
        }
    }

}
