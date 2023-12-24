using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CameraManager : MonoBehaviour
{
    private InputManager _inputManager;

    [SerializeField] private float _sensitvity = 1f;


    // cinemachine
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;

    public GameObject CinemachineCameraTarget;

    private const float _threshold = 0.01f;
    public bool LockCameraPosition = false;

    public float CameraAngleOverride = 0.0f;

    public float TopClamp = 70.0f;
    public float BottomClamp = -30.0f;


    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }
    private void Start()
    {
        _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;

    }
    public void HandleAllCameraMovement()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if ( _inputManager._cameraInputs.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            //Don't multiply mouse input by Time.deltaTime;
            float deltaTimeMultiplier = 1.0f;

            _cinemachineTargetYaw += _inputManager._cameraInputs.x * deltaTimeMultiplier * _sensitvity;
            _cinemachineTargetPitch += _inputManager._cameraInputs.y * deltaTimeMultiplier * _sensitvity;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);
    }


    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}
