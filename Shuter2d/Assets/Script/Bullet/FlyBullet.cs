using UnityEngine;

public class FlyBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private int _damage = 1;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    public void Launch(Vector2 direction)
    {
        _rb.linearVelocity = direction.normalized * _speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthPlayer healthPlayer = collision.gameObject.GetComponent<HealthPlayer>();
        if (healthPlayer != null)
            healthPlayer.TakeDamage(_damage);

        Destroy(gameObject);
    }
}
