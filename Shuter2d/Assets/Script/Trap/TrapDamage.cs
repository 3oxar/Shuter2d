using UnityEngine;

public class TrapDamage : MonoBehaviour
{

    [SerializeField] private int _damage;
    [SerializeField] private float _reloadTime = 1;

    private float _nextTimeDamage = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerHealth = collision.gameObject.GetComponent<HealthPlayer>();
        if (playerHealth != null && Time.time >= _nextTimeDamage)
        {
            playerHealth.TakeDamage(_damage);
            _nextTimeDamage = Time.time + _reloadTime;
        }
    }
}
