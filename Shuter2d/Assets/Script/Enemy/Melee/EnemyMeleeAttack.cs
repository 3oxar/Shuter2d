using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _fireRate = 0.5f;

    private float nextFireTime = 0;
    private EnemyAnimation _animator;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimation>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthPlayer healthPlayer = collision.gameObject.GetComponent<HealthPlayer>();

        if (healthPlayer != null &&   Time.time >= nextFireTime)
        {
            healthPlayer.TakeDamage(_damage);
            _animator.AnimAttack2();
            nextFireTime = Time.time + _fireRate;
        }
    }
}
