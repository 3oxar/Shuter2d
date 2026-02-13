using UnityEngine;

/// <summary>
/// Хотьба персонажа
/// </summary>
public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float _speed = 2;

    private Rigidbody2D _rb2;
    private Vector2 _moveInput;
    private PlayerController _inputPlayerController;
    private JumpPlayer _jumpPlayer;

    void Awake()
    {
        _rb2 = GetComponent<Rigidbody2D>();
        _inputPlayerController = new PlayerController();
        _jumpPlayer = GetComponent<JumpPlayer>();

        _inputPlayerController.Player.Move.performed += x => _moveInput = x.ReadValue<Vector2>();
        _inputPlayerController.Player.Move.canceled += x => _moveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        _inputPlayerController.Enable();
    }

    private void OnDisable()
    {
        _inputPlayerController.Disable();
    }

    void FixedUpdate()
    {
        _rb2.linearVelocity = new Vector2(_moveInput.x * _speed, _rb2.linearVelocityY);
    }
}
