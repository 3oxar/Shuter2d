using System;
using UnityEngine;

public class HealthPlayer : MonoBehaviour, IHealthPlayer
{
    public int Health { get => _healthPlayer; set => _healthPlayer = value; }

    [SerializeField] private int _healthPlayer = 10;
    [SerializeField] private TextCanvas _textCanvas;
    [SerializeField] private EndGamePlayer _endGame;

    private Animator _animPlayer;
    private void Start()
    {
       
        _textCanvas.WriteText(_healthPlayer.ToString());
        _animPlayer = GetComponent<Animator>();
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
        if (_healthPlayer <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        _endGame.EndGame();
    }

}
