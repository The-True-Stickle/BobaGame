using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterStuff : MonoBehaviour
{

    public void ServeDrink(BobaType bobaType)
    {

        GameObject.FindObjectOfType<BobaQueueManager>().ServeDrink(bobaType);
    }



}
