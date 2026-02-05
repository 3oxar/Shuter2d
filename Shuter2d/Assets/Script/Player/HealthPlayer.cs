using System;
using UnityEngine;

public class HealthPlayer : MonoBehaviour, IHealth
{
    [SerializeField] private int _healthPlayer = 10;

    public int Health { get => _healthPlayer; set => _healthPlayer = value; }

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
        Destroy(gameObject);
    }

}
