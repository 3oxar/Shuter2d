using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCanvas : MonoBehaviour
{
    [SerializeField] private string _textValue;

    private TextMeshProUGUI _text;
    
    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void WriteText(string value)
    {
        _text.text = $"{_textValue}: {value}";
    }
}
