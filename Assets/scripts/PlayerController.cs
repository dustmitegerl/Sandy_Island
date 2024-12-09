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
    Vector3 m_EulerAngleVelocity;


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

    private void Start()
    {
        m_EulerAngleVelocity = new Vector3(0, rotationSpeed, 0);
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
        //Find target velocity
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new(move.x * speed, rb.velocity.y, rb.velocity.z);

        //Align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate forces
        Vector3 velocityChange = targetVelocity - currentVelocity;

        //Limit force
        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    public void Rotate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
