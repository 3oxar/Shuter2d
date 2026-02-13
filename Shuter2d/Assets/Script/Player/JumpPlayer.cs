using System;
using UnityEngine;

/// <summary>
/// ”паравление прыжками персонажа
/// </summary>
public class JumpPlayer : MonoBehaviour
{
    [HideInInspector] public bool _isGrounded;

    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb2;
   
    private PlayerController _inputPlayerController;

    void Awake()
    {
        _rb2 = GetComponent<Rigidbody2D>();
        _inputPlayerController = new PlayerController();

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
        _isGrounded = SearchIsGround();
    }

    private void Jump()
    {
        if (_isGrounded)
            _rb2.linearVelocity = new Vector2(_rb2.linearVelocity.x, _jumpForce);
    }

    public bool SearchIsGround()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
}
