using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] ProjectilePool[] bobaPools;
    PlayerInput input;
    public Transform firePoint;
    public int maxBobaInCup;
    public int maxBobaInMouth;
    public float reloadTime;
    public bool bobaFresh = false;

    [Header("Debug")]
    public int currentBobaInCup;
    public BobaType currentBobaType;
    public int currentBobaInMouth;
    [SerializeField] private float reloadTimer;
    [SerializeField] private ProjectilePool currentBobaPool;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        currentBobaPool = bobaPools[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(input.attackKey))
        {
            Fire();
		}
	    if (Input.GetKey(input.reloadKey))
        {
            // Multiple Random.Range so it's more real lol
            reloadTimer += Time.deltaTime * Random.Range(1f, 3f);
            if (reloadTimer >= reloadTime)
            {
                Reload();
                reloadTimer = 0;
            }
        }
        if (Input.GetKeyDown(input.changeCupKey))
        {
           // GetNewCup();
		}
        //HandleSwitchDrink(null);
    }

    private void Reload()
    {
        if (currentBobaInCup <= 0)
        {
            Debug.Log("There is no more drinks! Right-click moush to change a new cup!");
            GameObject.FindObjectOfType<GameUIHandler>().updateDrinkImage(null);

            return;
		}
        if (currentBobaInMouth >= maxBobaInMouth)
        { 
            Debug.Log("Too much boba in mouth! Can't get anymore!");
            return;
		}
        AudioManager.Instance.PlayClip(AudioManager.Instance.reloadClip);
        currentBobaInMouth++;
        currentBobaInCup--;
        Debug.Log("Boba in Mouth: " + currentBobaInMouth + ", Boba in Cup: " + currentBobaInCup);
        bobaFresh = false;

        GameObject.FindObjectOfType<GameUIHandler>().updateDrinkImage(currentBobaType);
    }

    private void Fire()
    { 
	    if (currentBobaInMouth <= 0)
        {
            Debug.Log("There is no boba in mouth! Pressing R to reload!");
            return;
		}

        currentBobaInMouth--;
        Debug.Log("Boba in Mouth: " + currentBobaInMouth);
        AudioManager.Instance.PlayClip(AudioManager.Instance.shootClip);
        Projectile aProjectile = currentBobaPool.GetProjectile();
        aProjectile.transform.position = firePoint.position;
        aProjectile.transform.rotation = firePoint.rotation;
        aProjectile.gameObject.SetActive(true);
    }

    public void GetNewCup()
    {
        currentBobaInCup = maxBobaInCup;
        bobaFresh = true;
        Debug.Log("Got a new cup! Boba in Cup: " + currentBobaInCup);
	}


    public void HandleSwitchDrink(BobaType bobaType)
    {
        currentBobaType = bobaType;

        if (Input.GetKeyDown(input.brownSugarKey) || bobaType.bobaName == "Milk Tea")
        {
            currentBobaPool = bobaPools[0];
            Debug.Log("Change to " + currentBobaPool.name);
		}
	    if (Input.GetKeyDown(input.strawberryKey) || bobaType.bobaName == "Strawberry Tea")
        {
            currentBobaPool = bobaPools[1];
            Debug.Log("Change to " + currentBobaPool.name);
		}
	    if (Input.GetKeyDown(input.mochaKey) ||  bobaType.bobaName == "Matcha Tea")
        {
            currentBobaPool = bobaPools[2];
            Debug.Log("Change to " + currentBobaPool.name);
        }
        bobaFresh = true;
        GameObject.FindObjectOfType<GameUIHandler>().updateDrinkImage(bobaType);
    }

}
