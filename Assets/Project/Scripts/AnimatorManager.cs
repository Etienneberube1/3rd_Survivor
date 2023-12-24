using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator _animator;

    int _horizontalID;
    int _verticalID;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        GetAnimationHash();
    }

    private void GetAnimationHash()
    {
        _horizontalID = Animator.StringToHash("Horizontal");
        _verticalID = Animator.StringToHash("Vertical");
    }
       

    public void UpdateAnimatorValue(float horizontalMovement, float verticalMovement)
    {
       _animator.SetFloat(_horizontalID, horizontalMovement, 0.2f, Time.deltaTime);
        _animator.SetFloat(_verticalID, verticalMovement, 0.2f, Time.deltaTime);
    }
}
