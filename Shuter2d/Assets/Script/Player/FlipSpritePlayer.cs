using UnityEngine;

public class FlipSpritePlayer : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _moveInput;
    private PlayerController _inputPlayerController;
    private bool isRight = true;

    void Awake()
    {
        _inputPlayerController = new PlayerController();
        _animator = GetComponent<Animator>();

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

    
    void Update()
    {
        if (_moveInput.x > 0 && !isRight)
            Flip();
        else if (_moveInput.x < 0 && isRight)
            Flip();
    }

    private void Flip()
    {
        isRight = !isRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
