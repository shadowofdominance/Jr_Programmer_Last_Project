using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float rotationSpeed = 10f;

    private Rigidbody playerRb;
    public Camera mainCamera;
    private Vector3 moveDirection;

    public InputActionAsset inputActionAsset;
    private InputAction moveAction;

    private void OnEnable()
    {
        inputActionAsset.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActionAsset.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }
    private void Update()
    {
        Vector2 moveInputs = moveAction.ReadValue<Vector2>();

        // Flatten camera axes onto the horizontal plane
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Movement is now relative to where the camera is looking
        moveDirection = (cameraForward * moveInputs.y) + (cameraRight * moveInputs.x);

        // Rotate the player to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(moveDirection * playerSpeed, ForceMode.Force);
    }
}
