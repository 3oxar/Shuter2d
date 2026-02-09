using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSource;
    [SerializeField] private List<AudioSource> _audioSMusic;

    private float _volumeSave;
    private Slider _slider;

    private void Awake()
    {
        _volumeSave = PlayerPrefs.GetFloat("MusicVolume", 0.5f);

        foreach (var item in _audioSource)
        {
            item.volume = _volumeSave;
        }
        foreach (var item in _audioSMusic)
        {
            item.volume = _volumeSave;
        }

        _slider.onValueChanged.AddListener(delegate { UpdateValue(); });
    }

    public void UpdateValue()
    {
        foreach (var item in _audioSource)
        {
            item.volume = _slider.value;
        }

        PlayerPrefs.SetFloat("MusicVolume", _slider.value);
        PlayerPrefs.Save();
    }
}
