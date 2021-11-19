using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [Header("音量範圍")]
    public float _maxVolume = 0f;
    public float _minVolume = -30f;
    [Header("音量比例")]
    public float _Main_presentage = 50f;
    public float _BGM_presentage = 50f;
    public float _SFX_presentage = 50f;
    [Header("輸出音量")]
    public float _Main_volume;
    public float _BGM_volume;
    public float _SFX_volume;
    [Header("混音裝置")]
    public AudioMixer _audioMixer;

    public void SetMainVolume(float value)
    {
        if (value > 0)
        {
            _Main_presentage = value;
            _Main_volume = _Main_presentage / 100f * (_maxVolume - _minVolume) + _minVolume;
            _audioMixer.SetFloat("音量Master", _Main_volume);
        }
        else { _audioMixer.SetFloat("音量BGM", -80f); }
    }

    public void SetBGMVolume(float value)
    {
        if (value > 0)
        {
            _BGM_presentage = value;
            _BGM_volume = _BGM_presentage / 100f * (_maxVolume - _minVolume) + _minVolume;
            _audioMixer.SetFloat("音量BGM", _BGM_volume);
        }
        else { _audioMixer.SetFloat("音量BGM", -80f); }
    }

    public void SetSFXVolume(float value)
    {
        if (value > 0)
        {
            _SFX_presentage = value;
            _SFX_volume = _SFX_presentage / 100f * (_maxVolume - _minVolume) + _minVolume;
            _audioMixer.SetFloat("音量SFX", _SFX_volume);
        }
        else { _audioMixer.SetFloat("音量SFX", -80f); }
    }
}
