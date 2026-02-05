using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform firePoint;  
    [SerializeField] private float detectionRange = 3f;
    [SerializeField] private float fireRate = 2f;

    private Transform _player;
    private float _nextFireTime;
    private EnemyAnimation _animator; 

    void Start()
    {
        _player = FindAnyObjectByType<HealthPlayer>().transform;
        _animator = GetComponent<EnemyAnimation>();
    }

    void Update()
    {
        if (_player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distanceToPlayer <= detectionRange)
        {
            if (Time.time >= _nextFireTime)
            {
                Shoot();
                _animator.ActivTriggerAnim("Ability");
                _nextFireTime = Time.time + fireRate; 
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FlyBullet bullet = bulletGO.GetComponent<FlyBullet>();

        if (bullet != null)
        {
            Vector2 direction = (_player.position - firePoint.position).normalized;
            bullet.Launch(direction, gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
