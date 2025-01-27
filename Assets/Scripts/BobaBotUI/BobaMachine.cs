using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class BobaMachine : MonoBehaviour
{

    private bool currentlyMakingDrink = false;

    [SerializeField]
    private List<GameObject> drinks = new List<GameObject>();

    public bool drinkInMachine = false;
    public BobaType currentBobaType;

    private void Start()
    {
        Debug.Log("Boba Machine Started");

        //StartCoroutine(delayedTest());
       // StartCoroutine(delayedTest());
    }

    private IEnumerator delayedTest()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Delayed Test");
        if (BobaBotManager.instance != null)
        {
            BobaBotManager.instance.OpenBobaBotUI(this);
        }
        else
        {
            Debug.Log("BobaBotManager is null");
        }
        //BobaBotManager.instance.OpenBobaBotUI(this);
    }

    public void openBobaUI()
    {
        if (currentlyMakingDrink)
        {
            Debug.Log("Currently making a drink, cannot make another");
            return;
        }
        BobaBotManager.instance.OpenBobaBotUI(this);


    }

    public void makeBoba(BobaType bobaType)
    {
        Debug.Log("Making Boba of type: " + bobaType.name);

        StartCoroutine(makeBobaCoroutine(bobaType));
        BobaBotManager.instance.CloseBobaBotUI();
    }

    private IEnumerator makeBobaCoroutine(BobaType bobaType)
    {
        currentlyMakingDrink = true;
        // TODO: This will be blocked when drinking sfx is playing
        AudioManager.Instance.machineWorkingSource.Play();
        yield return new WaitForSeconds(bobaType.bobaWaitTime);
        AudioManager.Instance.machineWorkingSource.Stop();
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
        //DELETE
        //GameObject.FindAnyObjectByType<BobaQueueManager>().AddDrinkToQueue(bobaType);
        //GameObject.FindAnyObjectByType<BobaQueueManager>().AddDrinkToQueue(bobaType);
        //GameObject.FindAnyObjectByType<BobaQueueManager>().AddDrinkToQueue(bobaType);

        currentlyMakingDrink = false;
    }

    public void drinkTaken()
    {
        drinkInMachine = false;
        for (int i = 0; i < drinks.Count; i++)
        {
            drinks[i].SetActive(false);
        }
    }

}
