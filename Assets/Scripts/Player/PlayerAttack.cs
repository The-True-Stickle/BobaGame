using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
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
            Instantiate(projectilePrefab, firePoint.position, transform.rotation);
		}
    }
}
