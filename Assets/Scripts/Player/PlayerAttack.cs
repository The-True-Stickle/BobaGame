using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] ProjectilePool currentPool;
    PlayerInput input;
    public Transform firePoint;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(input.attackKey))
        {
            Projectile aProjectile = currentPool.GetProjectile();
            aProjectile.transform.position = firePoint.position;
            aProjectile.transform.rotation = transform.rotation;
            aProjectile.gameObject.SetActive(true);
		}
    }
}
