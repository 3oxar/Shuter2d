using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _healthPlayer = 10;
    [SerializeField] private GameObject _gameObject;

    public int Health { get =>  _healthPlayer;  set => _healthPlayer = value; }

    public void TakeDamage(int damage)
    {
        _healthPlayer -= damage;

        if (_healthPlayer <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(_gameObject);
    }

   
}
