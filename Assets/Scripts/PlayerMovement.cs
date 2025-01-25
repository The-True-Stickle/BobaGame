using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput input;

    [SerializeField] private float speed = 5f;
    private Vector3 direction;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        direction.x = input.horizontalInput;
        direction.y = input.verticalInput;
//        controller.Move();
    }

}
