using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Slider _sliderSound;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private AudioMixer _audioMixer;

    private float _volumeSaveMusic;
    private float _volumeSaveSound;

    private void Awake()
    {
        _volumeSaveMusic = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        _volumeSaveSound = PlayerPrefs.GetFloat("SoundVolume", 0.5f);

        SetSfxVolume(_volumeSaveSound);
        SetMusicVolume(_volumeSaveMusic);

        if (_sliderMusic != null)
        {
            _sliderMusic.value = _volumeSaveMusic;
            _sliderMusic.onValueChanged.AddListener(delegate { SetMusicVolume(_sliderMusic.value); });
        }
        if ( _sliderSound != null)
        {
            _sliderSound.value = _volumeSaveSound;
            _sliderSound.onValueChanged.AddListener(delegate { SetSfxVolume(_sliderSound.value); });
        }

    }
    private void SetMusicVolume(float value)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    private void SetSfxVolume(float value)
    {
        _audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SoundVolume", value);
    }
}
