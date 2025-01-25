using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage;
    Rigidbody body;
    SphereCollider sphereCollider;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        body = GetComponent<Rigidbody>();
        body.AddForce(Vector3.forward * 50f, ForceMode.Impulse);
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
