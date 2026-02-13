using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private int _ammunation = 5;
    [SerializeField] private float _reloadTime = 3;
    [SerializeField] private TextCanvas _textCanvas;
    [SerializeField] private AudioSource _audioSource;

    private PlayerController _inputPlayerController;
    private float _nextFireTime = 0;
    private float _rotateZ;
    private int _ammunationCoutReload;

    private Vector3 _mousePosition;
    private Vector3 _worldMousePosition;
    private Vector2 _directionToTarget;

    void Awake()
    {
        _inputPlayerController = new PlayerController();
      

        _inputPlayerController.Player.Shoot.performed += x => Fire();
        _ammunationCoutReload = _ammunation;
    }

    private void Start()
    {
        _textCanvas.WriteText(_ammunation.ToString());
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
        if(Time.time >= _nextFireTime && _ammunation > 0)
        {
            _mousePosition = Mouse.current.position.ReadValue();
            _worldMousePosition = _mainCamera.ScreenToWorldPoint(_mousePosition);
            _worldMousePosition.z = 0;
            _directionToTarget = (_worldMousePosition - _firePoint.position).normalized;
            
         
            GameObject bulletGO = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            FlyBullet bulletScript = bulletGO.GetComponent<FlyBullet>();

            if (bulletScript != null)
            {
                _audioSource.Play();
                _ammunation--;
                _textCanvas.WriteText(_ammunation.ToString());
                bulletScript.Launch(_directionToTarget, gameObject);
            }

            if (_ammunation < 1)
            {
                StartCoroutine(WriteReloadAmmunation());
            }
            _nextFireTime = Time.time + _fireRate;
        }
    }

    private IEnumerator WriteReloadAmmunation()
    {
        yield return new WaitForSeconds(_reloadTime);
        _ammunation = 5;
        _textCanvas.WriteText(_ammunation.ToString());
    }
}
