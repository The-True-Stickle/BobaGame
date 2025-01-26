using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class BobaMachine : MonoBehaviour
{

    private bool currentlyMakingDrink = false;

    private void Start()
    {
        Debug.Log("Boba Machine Started");

        //StartCoroutine(delayedTest());
        StartCoroutine(delayedTest());
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
        yield return new WaitForSeconds(bobaType.bobaWaitTime);
        Debug.Log("Boba is ready");

        //DELETE
        GameObject.FindAnyObjectByType<BobaQueueManager>().AddDrinkToQueue(bobaType);
        GameObject.FindAnyObjectByType<BobaQueueManager>().AddDrinkToQueue(bobaType);
        GameObject.FindAnyObjectByType<BobaQueueManager>().AddDrinkToQueue(bobaType);

        currentlyMakingDrink = false;
    }


}
