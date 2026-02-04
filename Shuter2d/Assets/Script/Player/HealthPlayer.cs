using System;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private int _healthPlayer = 10;

    public void TakeDamage(int damage)
    {
        _healthPlayer -= damage;

        if(_healthPlayer <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
