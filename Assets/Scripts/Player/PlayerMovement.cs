using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput input;

    [SerializeField] private float speed = 5f;
    private Vector3 moveDirection;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void Update()
    {
    }

    private void HandleMovement()
    { 
        moveDirection.x = input.horizontalInput;
        moveDirection.z = input.verticalInput;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
	}

}
