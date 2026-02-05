using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _healthPlayer = 10;
    [SerializeField] private GameObject _gameObject;

    public void TakeDamage(int damage)
    {
        _healthPlayer -= damage;

        if (_healthPlayer <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(_gameObject);
    }
}
