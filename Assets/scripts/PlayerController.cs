// using InputSystem per the advice of the Unity manual
// using this tutorial for help: https://www.youtube.com/watch?v=HmXU4dZbaMw

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float runMultiplier;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    bool isRunning = false;
    [SerializeField]
    PlayerInputActions playerControls;
    [SerializeField]
    Vector3 moveDirection = Vector3.zero;
    InputAction move;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }
    // Start is called before the first frame update

    private void Update()
    {
        moveDirection = move.ReadValue<Vector3>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x, moveDirection.z) * moveSpeed; 
    }
}
