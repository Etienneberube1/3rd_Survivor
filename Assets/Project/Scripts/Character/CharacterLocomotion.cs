using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _input;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {   
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");

        _animator.SetFloat("Input_X", _input.x);
        _animator.SetFloat("Input_Y", _input.y);
    }
}
