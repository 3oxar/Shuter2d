using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _healthPlayer = 10;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private int _coutScore;

    public int Health { get =>  _healthPlayer;  set => _healthPlayer = value; }

    private ScorePlayer _score;

    private void Start()
    {
        _score = FindAnyObjectByType<ScorePlayer>();
    }

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
        _score.ScoreAdd(_coutScore);
        Destroy(_gameObject);
    }

   
}
