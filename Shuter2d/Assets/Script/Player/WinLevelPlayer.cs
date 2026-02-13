using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinLevelPlayer : MonoBehaviour
{
    [SerializeField] private Canvas _winGamePanel;
    [SerializeField] private Canvas _gamePanel;
    [SerializeField] private Button _menuButton;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ScorePlayer _scorePlayer;
    [SerializeField] private GameObject _endgame;

    void Start()
    {
        Time.timeScale = 1f;
        _text.text = "Очки: ";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<ScorePlayer>();

        if(player != null)
        {
            Time.timeScale = 0f;
            _text.text += _scorePlayer.CoutScorePlayer;
            _winGamePanel.gameObject.SetActive(true);
            _menuButton.gameObject.SetActive(false);
            _gamePanel.gameObject.SetActive(false);
            Destroy(_endgame);
            Destroy(player.gameObject);
            Destroy(gameObject);
        }
    }
}
