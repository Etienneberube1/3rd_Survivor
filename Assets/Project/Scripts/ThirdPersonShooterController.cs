using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _aimVirtualCamera;
    [SerializeField] private float _normalSensitivity;
    [SerializeField] private float _aimSensitivity;
    [SerializeField] private LayerMask _aimColliderLayerMask;



    private Animator _animator;
    private StarterAssetsInputs _inputs;
    private ThirdPersonController _controller;

    private Transform _hitTransform = null;
    private void Awake()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<ThirdPersonController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Aiming();

        // if the player is shooting calling the function else
        // we set the target back to null to prevent null ref
        if (Input.GetKey(KeyCode.Mouse0)) { Shoot(); }
        else { _hitTransform = null; }
        

    }


    private void Aiming()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);


        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimColliderLayerMask))
        {
            mouseWorldPosition = raycastHit.point;

            _hitTransform = raycastHit.transform;
        }


        if (_inputs.aim)
        {
            _aimVirtualCamera.gameObject.SetActive(true);
            _controller.SetSensivity(_aimSensitivity);
            _controller.SetRotateOnMove(false);


            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

        }
        else
        {
            _aimVirtualCamera.gameObject.SetActive(false);
            _controller.SetSensivity(_normalSensitivity);
            _controller.SetRotateOnMove(true);

        }

        AimAnimChange();
    }


    private void AimAnimChange()
    {
        if (_inputs.aim) { _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f)); }
        else { _animator.SetLayerWeight(1, Mathf.Lerp(_animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f)); }

        if (_inputs.aim && _inputs.move != Vector2.zero)
        {
            _animator.SetBool("Aim", true);
        }
        else
        {
            _animator.SetBool("Aim", false);
        }
    }

    private void Shoot()
    {
        if (_hitTransform != null)
        {
            print("Hit something");
        }
    }
}
