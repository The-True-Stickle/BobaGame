using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField]
    private CinemachineDollyCart dollyCart;

    private void Start()
    {
        dollyCart.m_Speed = moveSpeed;
    }


    public void DecreaseMoveSpeed(float amount)
    {
        moveSpeed = Mathf.Clamp(moveSpeed - amount, 0, moveSpeed);
        dollyCart.m_Speed = moveSpeed;

    }

    private void Update()
    {
        if (GameManager.gameState == "ACTIVE")
        {
            if (dollyCart.m_Position >= dollyCart.m_Path.PathLength)
            {

                GameObject.FindObjectOfType<BobaQueueManager>().enemyAddsDrink();

                Destroy(gameObject);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Triggered");
        if (collision.transform.tag == ("Register"))
        {

            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == ("Register"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
