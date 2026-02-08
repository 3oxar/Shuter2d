using UnityEngine;

public class ScorePlayer : MonoBehaviour
{
    public int CoutScorePlayer { get => _coutScorePlayer; set => _coutScorePlayer = value; }

    [SerializeField] private TextCanvas _textCanvas;

    private int _coutScorePlayer = 0;
    
    void Start()
    {
        _textCanvas.WriteText(_coutScorePlayer.ToString());
    }

    public void ScoreAdd(int cout)
    {
        _coutScorePlayer += cout;
        _textCanvas.WriteText(_coutScorePlayer.ToString());
    }
    
}
