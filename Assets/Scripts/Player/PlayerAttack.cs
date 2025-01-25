using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    public float fireForce;
    public Transform firePoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
		}
    }
}
