using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;
    private AnimatorManager _animatorManager;

    [SerializeField] public Vector2 _movementInputs;
    [SerializeField] public Vector2 _cameraInputs;

    public float _moveAmount;

    public float _cameraInputX;
    public float _cameraInputY;

    public float _verticalMovement;
    public float _horizontalMovement;

    public bool _isSprinting;

    private void Awake()
    {
        _animatorManager = GetComponent<AnimatorManager>();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();

    }


    private void HandleMovementInput()
    {
        _verticalMovement = _movementInputs.y;
        _horizontalMovement = _movementInputs.x;

        _cameraInputY = _cameraInputs.y;
        _cameraInputX = _cameraInputs.x;

        _moveAmount = Mathf.Abs(_horizontalMovement) + Mathf.Abs(_verticalMovement);
        if (!_isSprinting) {
            _moveAmount = Mathf.Clamp(_moveAmount, 0, 0.5f);
        }
        else {
            _moveAmount = Mathf.Clamp(_moveAmount, 0.5f, 1f);
        }

        _animatorManager.UpdateAnimatorValue(0, _moveAmount);
    }

    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();

            _playerControls.PlayerMovement.Movement.performed += i => _movementInputs = i.ReadValue<Vector2>();
            _playerControls.PlayerMovement.Camera.performed += i => _cameraInputs = i.ReadValue<Vector2>();
            _playerControls.PlayerMovement.Sprint.performed += i => _isSprinting = i.ReadValueAsButton();
        }

        _playerControls.Enable();
    }
    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
