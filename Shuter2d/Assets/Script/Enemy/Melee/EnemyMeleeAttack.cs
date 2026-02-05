using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _fireRate = 0.5f;

    private float nextFireTime = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthPlayer healthPlayer = collision.gameObject.GetComponent<HealthPlayer>();

        if (healthPlayer != null &&   Time.time >= nextFireTime)
        {
            healthPlayer.TakeDamage(_damage);
            nextFireTime = Time.time + _fireRate;
        }
    }
}
