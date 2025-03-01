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
        body.drag = 0;
        body.AddForce(transform.forward * fireForce, ForceMode.Impulse);
        StartCoroutine(ReleaseDelay());
    }

    private void OnCollisionEnter(Collision collision)
    {
        //sphereCollider.enabled = false;
        //body.velocity = Vector3.zero;
        //body.angularVelocity = Vector3.zero;
        body.drag = 5;
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            AudioManager.Instance.PlayClip(AudioManager.Instance.enemyHitClip);
            enemyHealth.TakeDamage(damage);
		}
        if (debuffSO != null && collision.gameObject.TryGetComponent(out Enemy enemy))
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
