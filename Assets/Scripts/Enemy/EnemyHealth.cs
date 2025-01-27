using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
    [SerializeField] float initHealth;

    [Header("Debug")]
    [SerializeField] float currentHealth;

    private void Start()
    {
        currentHealth = initHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
		}
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
	}

    public void Die()
    {
        currentHealth = 0;
	}
}

