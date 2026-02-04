using System;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 0.5f;

    private PlayerController _inputPlayerController;
    private float nextFireTime = 0;

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
            Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            nextFireTime = Time.time + _fireRate;
        }
        
    }
}
