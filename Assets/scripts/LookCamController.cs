using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookCamController : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;
    Vector2 look;
    [SerializeField] float speedH, speedV, yaw, pitch, maxPitch;
    void Update()
    {
        yaw += speedH * look.x;
        if ((pitch < maxPitch && look.y < 0) || (pitch > -maxPitch && look.y > 0))
        {
            pitch -= speedV * look.y;
        }

        if (yaw >= 360 || yaw <= -360)
        {
            yaw = 0;
        }
        transform.localEulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }


    private void OnEnable()
    {
        playerPrefab.SetActive(false);
    }

    private void OnDisable()
    {
        Reset();
        playerPrefab.SetActive(true);
    }

    private void Reset()
    {
        yaw = 0; pitch = 0; //reset cam
        transform.localRotation = Quaternion.identity;
    }
}
