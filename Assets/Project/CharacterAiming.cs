using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using TMPro;
public class CharacterAiming : MonoBehaviour
{
    [SerializeField] private Rig _aimLayer;

    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _aimDuration;

    [SerializeField] private CinemachineCameraOffset _cameraOffset;



    [SerializeField] private Vector3 _cameraAimOffset;
    private Vector3 _cameraBaseOffset;


    private Camera _mainCamera;
    RaycastWeapon _weapon;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _weapon = GetComponentInChildren<RaycastWeapon>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _cameraBaseOffset = _cameraOffset.m_Offset;
    }

    private void FixedUpdate()
    {
        // getting the y rotation of the camere
        float cameraYaw = _mainCamera.transform.rotation.eulerAngles.y;

        // blending the current rotation of the player to the Y rotation of the camera
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, cameraYaw, 0), _turnSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            StartCoroutine(ChangeCameraOffset(_cameraAimOffset, _aimDuration));
            _aimLayer.weight += Time.deltaTime / _aimDuration;
        }
        else
        {
            StartCoroutine(ChangeCameraOffset(_cameraBaseOffset, _aimDuration));
            _aimLayer.weight -= Time.deltaTime / _aimDuration;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _weapon.StartFiring();
        }
        if(_weapon._isFiring)
        {
            _weapon.UpdateFiring(Time.deltaTime);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _weapon.StopFiring();
        }

    }


    private IEnumerator ChangeCameraOffset(Vector3 targetOffset, float duration)
    {
        float elapsedTime = 0;
        Vector3 startingOffset = _cameraOffset.m_Offset;

        while (elapsedTime < duration)
        {
            _cameraOffset.m_Offset = Vector3.Lerp(startingOffset, targetOffset, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _cameraOffset.m_Offset = targetOffset; 
    }

}
