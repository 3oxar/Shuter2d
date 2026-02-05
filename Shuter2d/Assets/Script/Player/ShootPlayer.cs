using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private Camera _mainCamera;

    private PlayerController _inputPlayerController;
    private float nextFireTime = 0;

    private Vector3 _mousePosition;
    private Vector3 _worldMousePosition;
    private Vector2 _directionToTarget;

    void Awake()
    {
        _inputPlayerController = new PlayerController();

        _inputPlayerController.Player.Shoot.performed += x => Fire();
    }

    private void OnEnable()
    {
        _inputPlayerController.Enable();
    }

    private void OnDisable()
    {
        _inputPlayerController.Disable();
    }

    private void Fire()
    {
        if(Time.time >= nextFireTime)
        {
            _mousePosition = Mouse.current.position.ReadValue();
            _worldMousePosition = _mainCamera.ScreenToWorldPoint(_mousePosition);
            _worldMousePosition.z = 0;
            _directionToTarget = (_worldMousePosition - _firePoint.position).normalized;
           
         
            GameObject bulletGO = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            FlyBullet bulletScript = bulletGO.GetComponent<FlyBullet>();

            if (bulletScript != null)
            {
               
                bulletScript.Launch(_directionToTarget, gameObject);
            }
            nextFireTime = Time.time + _fireRate;
        }
        
    }
}
