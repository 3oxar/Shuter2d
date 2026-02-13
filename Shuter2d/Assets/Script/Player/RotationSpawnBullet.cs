using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationSpawnBullet : MonoBehaviour
{

    [SerializeField] private float _offset;
    [SerializeField] private float _radius;

    private Vector3 _mousePosition;
    private Vector3 _diference;
    private float _rotateZ;

    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _diference = _mousePosition - transform.position;
        _rotateZ = Mathf.Atan2(_diference.y, _diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _rotateZ + _offset);
        
    }
}
