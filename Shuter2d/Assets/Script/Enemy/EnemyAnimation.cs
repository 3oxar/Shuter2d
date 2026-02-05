using System;
using System.Collections;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimIdle()
    {
        _animator.SetBool("Idle", !_animator.GetBool("Idle"));
    }

    public void AnimAbility()
    {
        _animator.SetBool("Ability", !_animator.GetBool("Ability"));
    }
    
    public void AnimAttack2()
    {
        _animator.SetBool("Attack 2", !_animator.GetBool("Attack 2"));
        
    }

    public void AnimRun()
    {

        _animator.SetBool("Run", !_animator.GetBool("Run"));
    }

}
