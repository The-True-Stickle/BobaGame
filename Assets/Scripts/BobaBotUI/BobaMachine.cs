using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class BobaMachine : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("Boba Machine Started");

        StartCoroutine(delayedTest());
    }

    private IEnumerator delayedTest()
    {
        yield return new WaitForSeconds(2);
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

    public void makeBoba(BobaType bobaType)
    {
        Debug.Log("Making Boba of type: " + bobaType.name);

        BobaBotManager.instance.CloseBobaBotUI();
    }



}
