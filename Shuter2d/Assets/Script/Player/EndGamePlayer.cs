using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePlayer : MonoBehaviour
{
    [SerializeField] private Canvas _endGamePanel;
    [SerializeField] private Canvas _gamePanel;
    [SerializeField] private Button _menuButton;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ScorePlayer _scorePlayer;

    void Start()
    {
        Time.timeScale = 1f;
        _text.text = "Очки: ";
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        _text.text += _scorePlayer.CoutScorePlayer;
        _endGamePanel.gameObject.SetActive(true);
        _menuButton.gameObject.SetActive(false);
        _gamePanel.gameObject.SetActive(false);
    }
    
}
