//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Windows;
//using static Cinemachine.CinemachineTargetGroup;

//public class ThirdPersonController : MonoBehaviour
//{
//    // Variables for movement
//    [SerializeField] private float _walkSpeed;
//    [SerializeField] private float _runSpeed;
//    [SerializeField] private float _rotationSmoothTime = 0.12f;
//    [SerializeField] private bool _rotateOnMove = true;

//    private CharacterController _controller;
//    private Transform _cameraObject;
//    private InputManager _inputManager;

//    private void Awake()
//    {
//        _controller = GetComponent<CharacterController>();
//        _cameraObject = Camera.main.transform;

//        // Initialize other necessary components and variables...
//    }

//    private void Update()
//    {
//        HandleMovement();
//        HandleRotation();
//    }

//    private void HandleMovement()
//    {
        
//        // Retrieve input and calculate target speed
//        float targetSpeed = _inputManager._movementInputs ? _runSpeed : _walkSpeed;

//        // Logic for movement direction
//        Vector3 moveDirection = _cameraObject.forward * _inputManager.move.y + _cameraObject.right * _inputManager.move.x;
//        moveDirection.Normalize();
//        moveDirection.y = 0;

//        // Calculate new speed based on input and apply movement
//        float currentSpeed = _controller.velocity.magnitude;
//        float newSpeed = Mathf.Lerp(currentSpeed, targetSpeed * _inputManager.move.magnitude, Time.deltaTime * SpeedChangeRate);
//        moveDirection *= newSpeed * Time.deltaTime;

//        // Apply movement to the character controller
//        _controller.Move(moveDirection);
//    }

//    private void HandleRotation()
//    {
//        Vector3 targetDirection = _cameraObject.forward * _inputManager.look.y + _cameraObject.right * _input.look.x;
//        targetDirection.Normalize();
//        targetDirection.y = 0;

//        if (targetDirection == Vector3.zero)
//        {
//            targetDirection = transform.forward;
//        }

//        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
//        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSmoothTime * Time.deltaTime);

//        transform.rotation = playerRotation;
//    }

//    // Other methods, variables, and functionalities...
//}
