//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerManager : MonoBehaviour
//{
//    private InputManager _inputManager;
//    private PlayerLocomotion _playerLocomotion;
//    private CameraManager _cameraManager;

//    private void Awake()
//    {
//        _inputManager = GetComponent<InputManager>();
//        _playerLocomotion = GetComponent<PlayerLocomotion>();
//        _cameraManager = FindAnyObjectByType<CameraManager>();

//        // making the cursor invisible and locked in
//        // in the middle on the screen
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
//    }

//    private void Update()
//    {
//        _inputManager.HandleAllInputs();
//    }

//    private void FixedUpdate()
//    {
//        _playerLocomotion.HandleAllMovements();
//    }

//    private void LateUpdate()
//    {
//        _cameraManager.HandleAllCameraMovement();
//    }
//}
