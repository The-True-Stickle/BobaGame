using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    public void DecreaseMoveSpeed(float amount)
    {
        moveSpeed = Mathf.Clamp(moveSpeed - amount, 0, moveSpeed);
	}
}
