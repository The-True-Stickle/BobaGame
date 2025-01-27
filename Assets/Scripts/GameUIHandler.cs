using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Stars")]
    [SerializeField]
    private List<Image> stars = new List<Image>();
    [SerializeField]
    private Sprite fullStar;
    [SerializeField]
    private Sprite emptyStar;
    [SerializeField]
    private Sprite halfStar;


    private void Start()
    {

        currentDrinkImage.enabled = false;
    }

    private void Update()
    {
        if (playerAttack.currentBobaInCup > 0)
        {
            bobaDrankText.text = "Boba Drank: " + playerAttack.currentBobaInMouth;
            if (playerAttack.currentBobaInMouth == playerAttack.maxBobaInMouth)
            {
                bobaDrankText.text = "Boba Drank: " + playerAttack.currentBobaInMouth + " (max)";
            }
        }
        else
        {
            bobaDrankText.text = "Boba Drank: 0";
        }

        updateStars();
    }

    public void updateStars()
    {

        switch(GameManager.starRating)
        {
            case 0:
                stars[0].sprite = emptyStar;
                stars[1].sprite = emptyStar;
                stars[2].sprite = emptyStar;
                stars[3].sprite = emptyStar;
                stars[4].sprite = emptyStar;
                //DIE
                GameObject.FindObjectOfType<PlayerDeath>().Die();
                if (GameObject.FindGameObjectWithTag("Player") != null)
                {
                    GameObject.FindGameObjectWithTag("Player").SetActive(false);

                }

                break;
            case 1:
                stars[0].sprite = halfStar;
                stars[1].sprite = emptyStar;
                stars[2].sprite = emptyStar;
                stars[3].sprite = emptyStar;
                stars[4].sprite = emptyStar;
                break;
            case 2:
                stars[0].sprite = fullStar;
                stars[1].sprite = emptyStar;
                stars[2].sprite = emptyStar;
                stars[3].sprite = emptyStar;
                stars[4].sprite = emptyStar;
                break;
            case 3:
                stars[0].sprite = fullStar;
                stars[1].sprite = halfStar;
                stars[2].sprite = emptyStar;
                stars[3].sprite = emptyStar;
                stars[4].sprite = emptyStar;
                break;
            case 4:
                stars[0].sprite = fullStar;
                stars[1].sprite = fullStar;
                stars[2].sprite = emptyStar;
                stars[3].sprite = emptyStar;
                stars[4].sprite = emptyStar;
                break;
            case 5:
                stars[0].sprite = fullStar;
                stars[1].sprite = fullStar;
                stars[2].sprite = halfStar;
                stars[3].sprite = emptyStar;
                stars[4].sprite = emptyStar;
                break;
            case 6:
                stars[0].sprite = fullStar;
                stars[1].sprite = fullStar;
                stars[2].sprite = fullStar;
                stars[3].sprite = emptyStar;
                stars[4].sprite = emptyStar;
                break;
            case 7:
                stars[0].sprite = fullStar;
                stars[1].sprite = fullStar;
                stars[2].sprite = fullStar;
                stars[3].sprite = halfStar;
                stars[4].sprite = emptyStar;
                break;
            case 8:
                stars[0].sprite = fullStar;
                stars[1].sprite = fullStar;
                stars[2].sprite = fullStar;
                stars[3].sprite = fullStar;
                stars[4].sprite = emptyStar;
                break;
            case 9:
                stars[0].sprite = fullStar;
                stars[1].sprite = fullStar;
                stars[2].sprite = fullStar;
                stars[3].sprite = fullStar;
                stars[4].sprite = halfStar;
                break;
            case 10:
                stars[0].sprite = fullStar;
                stars[1].sprite = fullStar;
                stars[2].sprite = fullStar;
                stars[3].sprite = fullStar;
                stars[4].sprite = fullStar;
                break;
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
