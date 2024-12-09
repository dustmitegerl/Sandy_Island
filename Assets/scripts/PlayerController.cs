using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject lookCam;
    [SerializeField] GameObject camHolder;
    [SerializeField] Vector2 move, look;
    [SerializeField] float speed, jumpThrust, sensitivity, maxForce, rotationSpeed;
    [SerializeField] bool isJumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(transform.up * jumpThrust);
            Debug.Log("jumping");
        }
    }
    
    //toggles camera
    public void OnFocus(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            lookCam.SetActive(true);
        }
        else if (context.canceled) 
        {
            lookCam.SetActive(false);
        }
     
    }
    private void Update()
    {
        if (rb.velocity.y != 0)
        {
            isJumping = true;
        }
        else isJumping = false;
    }
    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + transform.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime);
    }

    public void Rotate()
    {
        float turn = move.x * rotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
