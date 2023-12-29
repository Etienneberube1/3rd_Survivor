using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public bool _isFiring = false;

    [SerializeField, Tooltip("the value is the number of ms between each shoot, the lower the value the the more the shooting is slow")] 
    private int _fireRate = 25;

    [SerializeField] private ParticleSystem[] _muzzleFlash;
    [SerializeField] private ParticleSystem _hitEffect;

    [SerializeField] private TrailRenderer _bulletTracer;

    [SerializeField] private Transform _raycastOrigin;
    [SerializeField] private Transform _raycastDestination;

    private Ray _ray;
    private RaycastHit _raycastHit;

    private float _accumulatedTime;


    public void StartFiring()
    {
        _isFiring = true;
        _accumulatedTime = 0.0f;
    }

    public void StopFiring()
    {
        _isFiring = false;
    }

    public void UpdateFiring(float deltaTime)
    { 
        _accumulatedTime += deltaTime;
        float fireInterval = 1.0f / _fireRate;
        while ( _accumulatedTime > 0.0f )
        {
            FireBullet();
            _accumulatedTime -= fireInterval;
        }
    }


    private void FireBullet()
    {
        foreach (var particle in _muzzleFlash)
        {
            particle.Emit(1);
        }

        _ray.origin = _raycastOrigin.position;
        _ray.direction = _raycastDestination.position - _raycastOrigin.position;

        var tracer = Instantiate(_bulletTracer, _ray.origin, Quaternion.identity);
        tracer.AddPosition(_ray.origin);

        if (Physics.Raycast(_ray, out _raycastHit))
        {
            tracer.transform.position = _raycastHit.point;
        }

    }
}
