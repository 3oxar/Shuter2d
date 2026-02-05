using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _moveInput;
    private PlayerController _inputPlayerController;
    private JumpPlayer _jumpPlayer;
    private bool _isJump;


    void Awake()
    {
        _inputPlayerController = new PlayerController();
        _animator = GetComponent<Animator>();
        _jumpPlayer = GetComponent<JumpPlayer>();

        _inputPlayerController.Player.Move.performed += x => _moveInput = x.ReadValue<Vector2>();
        _inputPlayerController.Player.Move.canceled += x => _moveInput = Vector2.zero;
        _inputPlayerController.Player.Jump.performed += x => _isJump = true;
        _inputPlayerController.Player.Jump.canceled += x => _isJump = false;
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
        _animator.SetFloat("Run", Mathf.Abs(_moveInput.x));
        _animator.SetBool("IsGround", _jumpPlayer._isGrounded);
        _animator.SetBool("Jump", _isJump);
       

    }
}
