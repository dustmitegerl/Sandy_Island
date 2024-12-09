using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookCamController : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;
    Vector2 look;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    void Update()
    {
        yaw += speedH * look.x;
        while (pitch < 90 && pitch > -90)
        {
            pitch -= speedV * look.y;
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
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
        playerPrefab.SetActive(true);
    }
}
