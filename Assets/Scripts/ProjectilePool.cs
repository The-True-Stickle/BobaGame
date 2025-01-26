using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] float initSize;
    [SerializeField] Projectile projectilePrefab;
    Stack<Projectile> stack;


    private void Start()
    {
        SetupPool();
    }

    private void SetupPool()
    { 
        stack = new();
        Projectile instance = null;
        for (int i=0; i<initSize; i++)
        {
            instance = Instantiate(projectilePrefab);
            instance.pool = this;
            stack.Push(instance);
            instance.gameObject.SetActive(false);
		}
	}

    public Projectile GetProjectile()
    { 
        if (stack.Count <= 0)
        { 
            Projectile instance = Instantiate(projectilePrefab);
            instance.pool = this;
            stack.Push(instance);
            instance.gameObject.SetActive(false);
            return instance;
		}

        return stack.Pop();
	}

    public void PushToStack(Projectile projectile)
    {
        stack.Push(projectile);
        projectile.gameObject.SetActive(false);
	}
}
