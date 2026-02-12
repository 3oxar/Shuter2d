using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _healthPlayer = 10;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private int _coutScore;
    [SerializeField] private AudioSource _audioDamageSource;

    public int Health { get =>  _healthPlayer;  set => _healthPlayer = value; }

    private ScorePlayer _score;
    private AudioSource _audioSource;
    private Animator _animator;

    private void Start()
    {
        _score = FindAnyObjectByType<ScorePlayer>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        Debug.Log(_audioSource.clip.name);
    }

    public void TakeDamage(int damage)
    {
        _healthPlayer -= damage;
        _animator.SetTrigger("Hit");
        if (_healthPlayer <= 0)
        {
            Die();
        }
        else
        {
            _audioDamageSource.Play();
        }
    }

    public void Die()
    {
        _score.ScoreAdd(_coutScore);
        _audioSource.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(_gameObject, 0.5f);
    }

   
}
