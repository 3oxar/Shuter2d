using System;
using UnityEngine;

/// <summary>
/// ”паравление прыжками персонажа
/// </summary>
public class JumpPlayer : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb2;
    private Vector2 _moveInput;
    private PlayerController _inputPlayerController;
    private bool _isGrounded;

    void Awake()
    {
        _rb2 = GetComponent<Rigidbody2D>();
        _inputPlayerController = new PlayerController();

        _inputPlayerController.Player.Move.performed += x => _moveInput = x.ReadValue<Vector2>();
        _inputPlayerController.Player.Move.canceled += x => _moveInput = Vector2.zero;

        _inputPlayerController.Player.Jump.performed += x => Jump();
    }

   

    private void OnEnable()
    {
        _inputPlayerController.Enable();
    }

    private void OnDisable()
    {
        _inputPlayerController.Disable();
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius);
    }

    private void Jump()
    {
        if (_isGrounded)
            _rb2.linearVelocity = new Vector2(_rb2.linearVelocity.x, _jumpForce);
    }
}
