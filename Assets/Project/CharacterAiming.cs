using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _aimDuration;

    [SerializeField] private Rig _aimLayer;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        // getting the y rotation of the camere
        float cameraYaw = _mainCamera.transform.rotation.eulerAngles.y;

        // blending the current rotation of the player to the Y rotation of the camera
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, cameraYaw, 0), _turnSpeed * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1)) {
            _aimLayer.weight += Time.deltaTime / _aimDuration;
        }
        else {
            _aimLayer.weight -= Time.deltaTime / _aimDuration;
        }
    }
}
