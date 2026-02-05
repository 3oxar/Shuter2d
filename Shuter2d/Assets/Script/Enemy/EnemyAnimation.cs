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

    public void ActivTriggerAnim(string nameTrigger)
    {
        _animator.SetTrigger(nameTrigger);
    }
}
