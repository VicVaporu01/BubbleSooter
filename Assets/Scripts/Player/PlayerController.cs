using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform rotationPoint;

    private Vector2 mouseWorldPosition;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        mouseWorldPosition = Mouse.current.position.ReadValue();
        mouseWorldPosition = cam.ScreenToWorldPoint(mouseWorldPosition);

        // Debug.Log("Mouse Position: " + mouseWorldPosition);

        Vector2 toAim = mouseWorldPosition - (Vector2)rotationPoint.position;

        if (mouseWorldPosition.y > -3.50f)
        {
            transform.up = toAim;
        }
    }
}