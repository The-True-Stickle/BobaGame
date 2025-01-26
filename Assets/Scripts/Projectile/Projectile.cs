using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    Rigidbody body;
    SphereCollider sphereCollider;

    [SerializeField] ADebuffSO debuffSO;
    [SerializeField] float damage;
    [SerializeField] float fireForce;

    [Header("Debug")]
    public ProjectilePool pool;

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
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            debuffSO.Debuff(enemy);
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
