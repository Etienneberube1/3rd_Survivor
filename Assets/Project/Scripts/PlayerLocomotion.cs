using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private InputManager _inputManager;
    private Transform _cameraObject;
    private Rigidbody _playerRigidBody;

    private Vector3 _moveDirection;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;


    private void Awake()
    {
        _cameraObject = Camera.main.transform;

        _inputManager = GetComponent<InputManager>();
        _playerRigidBody = GetComponent<Rigidbody>();
    }




    public void HandleAllMovements()
    {
        HandleMovement();
        HandleRotation();
    }


    private void HandleMovement()
    {
        _moveDirection = _cameraObject.forward * _inputManager._verticalMovement;
        _moveDirection = _moveDirection + _cameraObject.right * _inputManager._horizontalMovement;
        _moveDirection.Normalize();
        _moveDirection.y = 0;
        _moveDirection *= _movementSpeed * Time.deltaTime;

        Vector3 movementVelocity = _moveDirection;
        _playerRigidBody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = _cameraObject.forward * _inputManager._verticalMovement;
        targetDirection = targetDirection + _cameraObject.right * _inputManager._horizontalMovement;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero) { targetDirection = transform.forward; }


        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
}
