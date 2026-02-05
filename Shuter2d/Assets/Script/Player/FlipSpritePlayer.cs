using UnityEngine;
using UnityEngine.InputSystem;

public class FlipSpritePlayer : MonoBehaviour
{
   
    private PlayerController _inputPlayerController;
    private bool isRight = true;
    private Vector3 _mousePosition;
    

    void Awake()
    {
        _inputPlayerController = new PlayerController();
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
        _mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (_mousePosition.x > transform.position.x && !isRight)
            Flip();
        else if (_mousePosition.x < transform.position.x && isRight)
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
