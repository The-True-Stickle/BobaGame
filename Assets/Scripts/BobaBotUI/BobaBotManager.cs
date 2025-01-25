using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BobaBotManager : MonoBehaviour
{

    [SerializeField]
    private List<BobaType> bobaTypes = new List<BobaType>();


    [System.Serializable]
    public struct BobaMenuType
    {
        public Button bobaButton;
        public TextMeshProUGUI bobaName;
        public Image bobaImage;
        public TextMeshProUGUI bobaWaitTime;
        public TextMeshProUGUI bobaDesc;
    }

    [SerializeField]
    private List<BobaMenuType> menuComponent = new List<BobaMenuType>();


    private void Start()
    {
        for (int i = 0; i < bobaTypes.Count; i++)
        {
            menuComponent[i].bobaName.text = bobaTypes[i].bobaName;
            menuComponent[i].bobaImage.sprite = bobaTypes[i].bobaImage;
            menuComponent[i].bobaWaitTime.text = bobaTypes[i].bobaWaitTime.ToString();
            menuComponent[i].bobaDesc.text = bobaTypes[i].bobaDesc;
        }

        if (bobaTypes.Count < menuComponent.Count)
        {
            for (int i = bobaTypes.Count; i < menuComponent.Count; i++)
            {
                menuComponent[i].bobaButton.gameObject.SetActive(false);
            }
        }
    }



}
