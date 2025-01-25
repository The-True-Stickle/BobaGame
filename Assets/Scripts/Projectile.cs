using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    Rigidbody body;
    SphereCollider sphereCollider;

    [SerializeField] float damage;
    [SerializeField] float fireForce;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        body = GetComponent<Rigidbody>();
        body.AddForce(Vector3.forward * fireForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        sphereCollider.enabled = false;
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(damage);
		}
    }
}
