using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BobaBotManager : MonoBehaviour
{

    [SerializeField]
    private List<BobaType> bobaTypes = new List<BobaType>();

    public static BobaBotManager instance = null;

    [System.Serializable]
    public struct BobaMenuType
    {
        public Button bobaButton;
        public TextMeshProUGUI bobaName;
        public Image bobaImage;
        public TextMeshProUGUI bobaWaitTime;
        public TextMeshProUGUI bobaDesc;
    }

    public PlayerLook playerLook;

    [SerializeField]
    private List<BobaMenuType> menuComponent = new List<BobaMenuType>();

    [SerializeField]
    private GameObject bobaBotUI;

    private BobaMachine currentlyUsedScript;

    public bool menuOpen = false;

    private void Start()
    {

        instance = this;

        for (int i = 0; i < bobaTypes.Count; i++)
        {
            menuComponent[i].bobaName.text = bobaTypes[i].bobaName;
            menuComponent[i].bobaImage.sprite = bobaTypes[i].bobaImage;
            menuComponent[i].bobaWaitTime.text = bobaTypes[i].bobaWaitTime.ToString() + " Seconds";
            menuComponent[i].bobaDesc.text = bobaTypes[i].bobaDesc;
            //menuComponent[i].bobaButton.onClick.AddListener(delegate { MakeBoba(i); });
        }

        if (bobaTypes.Count < menuComponent.Count)
        {
            for (int i = bobaTypes.Count; i < menuComponent.Count; i++)
            {
                menuComponent[i].bobaButton.gameObject.SetActive(false);
            }
        }

    }

    public void OpenBobaBotUI(BobaMachine machineScript)
    {
        bobaBotUI.SetActive(true);
        menuOpen = true;
        playerLook.toggleMouseInput(false);
        currentlyUsedScript = machineScript;

    }

    public void CloseBobaBotUI()
    {
        bobaBotUI.SetActive(false);
        playerLook.toggleMouseInput(true);

        menuOpen = false;
    }

    public void MakeBoba(int bobaType)
    {


        Debug.Log("Making Boba of type: " + bobaType);
        currentlyUsedScript.makeBoba(bobaTypes[bobaType]);




    }

}
