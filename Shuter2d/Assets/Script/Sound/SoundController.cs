using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioMusic;
    [SerializeField] private List<AudioSource> _audioSound;
    [SerializeField] private Slider _sliderSound;
    [SerializeField] private Slider _sliderMusic;

    private float _volumeSaveMusic;
    private float _volumeSaveSound;

    private void Awake()
    {
        _volumeSaveMusic = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        _volumeSaveSound = PlayerPrefs.GetFloat("SoundVolume", 0.5f);

        SetVolume(_audioMusic, _volumeSaveMusic);
        SetVolume(_audioSound, _volumeSaveSound);

        if(_sliderMusic != null)
            _sliderMusic.value = _volumeSaveMusic;
        if( _sliderSound != null)
            _sliderSound.value = _volumeSaveSound;  

        _sliderMusic.onValueChanged.AddListener(delegate { UpdateMusicValue(); });
        _sliderSound.onValueChanged.AddListener(delegate { UpdateSoundValue(); });
    }

    public void UpdateMusicValue()
    {
        SetVolume(_audioMusic, _sliderMusic.value);
        PlayerPrefs.SetFloat("MusicVolume", _sliderMusic.value);
    }
    
    public void UpdateSoundValue()
    {
        SetVolume(_audioSound, _sliderSound.value);
        PlayerPrefs.SetFloat("SoundVolume", _sliderSound.value);
    }

    private void SetVolume(List<AudioSource> audioSources, float volume)
    {
        foreach(var audioSource in audioSources)
        {
            if(audioSource != null) audioSource.volume = volume;
        }
    }
}
