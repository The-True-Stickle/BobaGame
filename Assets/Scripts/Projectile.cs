using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    Rigidbody body;
    SphereCollider sphereCollider;

    public ProjectilePool pool;
    [SerializeField] float damage;
    [SerializeField] float fireForce;

    private void OnEnable()
    {
        sphereCollider = GetComponent<SphereCollider>();
        body = GetComponent<Rigidbody>();
        body.AddForce(transform.forward * fireForce, ForceMode.Impulse);
        StartCoroutine(ReleaseDelay());
    }

    private void OnCollisionEnter(Collision collision)
    {
        //sphereCollider.enabled = false;
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(damage);
		}
    }

    public void Release()
    {
        pool.PushToStack(this);
	}

    IEnumerator ReleaseDelay()
    {
        yield return new WaitForSeconds(3f);
        Release();
	}
}
