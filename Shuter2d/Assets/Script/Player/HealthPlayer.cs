using System;
using UnityEngine;

public class HealthPlayer : MonoBehaviour, IHealthPlayer
{
    public int Health { get => _healthPlayer; set => _healthPlayer = value; }

    [SerializeField] private int _healthPlayer = 10;
    [SerializeField] private TextCanvas _textCanvas;
    [SerializeField] private EndGamePlayer _endGame;
    [SerializeField] private AudioSource _audioDamageSource;

    private Animator _animPlayer;
    private AudioSource _audioSource;
    private void Start()
    {
       
        _textCanvas.WriteText(_healthPlayer.ToString());
        _animPlayer = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void HealthUp(int cout)
    {
        _healthPlayer += cout;
        _textCanvas.WriteText(_healthPlayer.ToString());

    }

    public void TakeDamage(int damage)
    {
        _healthPlayer -= damage;
        _textCanvas.WriteText(_healthPlayer.ToString());
        _animPlayer.SetTrigger("Damage");
        _audioDamageSource.Play();
        if (_healthPlayer <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _audioSource.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 0.5f);
        _endGame.EndGame();
    }

}
