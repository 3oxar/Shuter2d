using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint;  
    public float detectionRange = 3f;
    public float fireRate = 2f;

    private Transform player;
    private float nextFireTime;

    void Start()
    {
        player = FindAnyObjectByType<HealthPlayer>().transform;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate; 
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FlyBullet bullet = bulletGO.GetComponent<FlyBullet>();

        if (bullet != null)
        {
            Vector2 direction = (player.position - firePoint.position).normalized;
            bullet.Launch(direction);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
