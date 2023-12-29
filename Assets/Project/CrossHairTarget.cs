using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    private Camera _camera;
    private Ray _ray;
    RaycastHit _raycastHit;
    
    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        _ray.origin = _camera.transform.position;
        _ray.direction = _camera.transform.forward;

        Physics.Raycast(_ray, out _raycastHit);
        transform.position = _raycastHit.point;
    }
}
