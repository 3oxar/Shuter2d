using UnityEngine;

public class FlyBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private int _damage = 1;
    private Rigidbody2D _rb;
    private Collider2D _bulletColl;
    private Collider2D _actorFire;
    private Rigidbody2D _hitRB;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    public void Launch(Vector2 direction, GameObject actor)
    {
        _bulletColl = gameObject.GetComponent<Collider2D>();
        _actorFire = actor.GetComponent<Collider2D>();

        if (_bulletColl != null && _actorFire != null)
            Physics2D.IgnoreCollision(_bulletColl, _actorFire);

        _rb.linearVelocity = direction.normalized * _speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHealth health = collision.gameObject.GetComponent<IHealth>();
        if (health != null)
            health.TakeDamage(_damage);

        _hitRB = collision.gameObject.GetComponent<Rigidbody2D>();
        if (_hitRB != null)
            _hitRB.linearVelocity = Vector2.zero;
            
        Destroy(gameObject);
    }
}
