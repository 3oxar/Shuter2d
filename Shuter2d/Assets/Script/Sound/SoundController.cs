using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioMusic;
    [SerializeField] private List<AudioSource> _audioSound;

    private float _volumeSaveMusic;
    private float _volumeSaveSound;
    private Slider _sliderMusic;
    private Slider _sliderSound;

    private void Awake()
    {
        _volumeSaveMusic = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        _volumeSaveSound = PlayerPrefs.GetFloat("MusicSound", 0.5f);
        
        foreach (var item in _audioMusic)
        {
            item.volume = _volumeSaveMusic;
        }
        foreach (var item in _audioSound)
        {
            item.volume = _volumeSaveSound;
        }
        _sliderMusic.onValueChanged.AddListener(delegate { UpdateMusicValue(); });
        _sliderSound.onValueChanged.AddListener(delegate { UpdateSoundValue(); });
    }

    public void UpdateMusicValue()
    {
        foreach (var item in _audioSound)
        {
            item.volume = _sliderMusic.value;
        }

        PlayerPrefs.SetFloat("MusicVolume", _sliderMusic.value);
        PlayerPrefs.Save();
    }
    
    public void UpdateSoundValue()
    {
        foreach (var item in _audioSound)
        {
            item.volume = _sliderSound.value;
        }

        PlayerPrefs.SetFloat("SoundVolume", _sliderSound.value);
        PlayerPrefs.Save();
    }
}
