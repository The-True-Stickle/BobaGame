using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] ProjectilePool currentPool;
    PlayerInput input;
    public Transform firePoint;
    public int maxBobaInCup;
    public int maxBobaInMouth;
    public float reloadTime;

    [Header("Debug")]
    public int currentBobaInCup;
    public int currentBobaInMouth;
    [SerializeField] private float reloadTimer;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        GetNewCup();
    }

    private void Update()
    {
        if (Input.GetKeyDown(input.attackKey))
        {
            Fire();
		}
	    if (Input.GetKey(input.reloadKey))
        {
            reloadTimer += Time.deltaTime * Random.Range(1f, 3f);
            if (reloadTimer >= reloadTime)
            {
                Reload();
                reloadTimer = 0;
            }
        }
        if (Input.GetKeyDown(input.changeCupKey))
        {
            GetNewCup();
		}
    }

    private void Reload()
    {
        if (currentBobaInCup <= 0)
        {
            Debug.Log("There is no more drinks! Change a new cup!");
            return;
		}
        if (currentBobaInMouth >= maxBobaInMouth)
        { 
            Debug.Log("Too much boba in mouth! Can get anymore!");
            return;
		}
        currentBobaInMouth++;
        currentBobaInCup--;
        Debug.Log("Boba in Mouth: " + currentBobaInMouth + ", Boba in Cup: " + currentBobaInCup);
    }

    private void Fire()
    { 
	    if (currentBobaInMouth <= 0)
        {
            Debug.Log("There is no boba in mouth! Press R to reload!");
            return;
		}

        currentBobaInMouth--;
        Debug.Log("Boba in Mouth: " + currentBobaInMouth);
        Projectile aProjectile = currentPool.GetProjectile();
        aProjectile.transform.position = firePoint.position;
        aProjectile.transform.rotation = transform.rotation;
        aProjectile.gameObject.SetActive(true);
    }

    private void GetNewCup()
    {
        currentBobaInCup = maxBobaInCup;
        Debug.Log("Get a new cup! Boba in Cup: " + currentBobaInCup);
	}
}
