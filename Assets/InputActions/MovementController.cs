using System;
using QuakeLR;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private QuakeCharacterController _CharacterController = null;
    
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = (transform.forward * moveY + transform.right * moveX).normalized;
        _CharacterController.Move(moveDirection); // don't multiply by deltratime!
        _CharacterController.ControllerThink(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _CharacterController.TryJump(); // don't call jump!
        }
    }

    private void Awake()
    {
        _CharacterController = GetComponent<QuakeCharacterController>();

    }
}
