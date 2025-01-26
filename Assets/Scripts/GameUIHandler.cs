using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{

    [Header("Management")]
    [SerializeField]
    private PlayerAttack playerAttack;


    [Header("Current Drink")]
    [SerializeField] private Image currentDrinkImage;
    [SerializeField]
    private List<Sprite> drinkSprites = new List<Sprite>();

    [Header("Boba Drank")]
    [SerializeField]
    private TextMeshProUGUI bobaDrankText;


    private void Start()
    {

        currentDrinkImage.enabled = false;
    }

    private void Update()
    {
        if (playerAttack.currentBobaInCup > 0)
        {
            bobaDrankText.text = "Boba Drank: " + playerAttack.currentBobaInMouth;
        }
        else
        {
            bobaDrankText.text = "Boba Drank: 0";
        }
    }

    public void updateDrinkImage(BobaType bobaType)
    {

        if (bobaType == null)
        {
            currentDrinkImage.enabled = false;
            return;
        }


        int drinkVal = 0;
        switch (bobaType.bobaName)
        {
            case "Milk Tea":
                drinkVal = 0;
                break;
            case "Matcha Tea":
                drinkVal = 1;
                break;
            case "Strawberry Tea":
                drinkVal = 2;
                break;
        }

        if (!playerAttack.bobaFresh)
        {
            currentDrinkImage.sprite = drinkSprites[drinkVal + 3];
        }
        else
        {
            currentDrinkImage.sprite = drinkSprites[drinkVal];
        }

        currentDrinkImage.enabled = true;

    }

}
