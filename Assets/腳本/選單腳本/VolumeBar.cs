using UnityEngine;
using UnityEngine.UI;

public class VolumeBar : MonoBehaviour
{
    public Text _main_Rate;
    public Text _BGM_Rate;
    public Text _SFX_Rate;

    public void MainBar(float value)
    {
        _main_Rate.text = value.ToString() + '%';
        FindObjectOfType<AudioMixerController>().SetMainVolume(value);
    }

    public void BGMBar(float value)
    {
        _BGM_Rate.text = value.ToString() + '%';
        FindObjectOfType<AudioMixerController>().SetBGMVolume(value);
    }

    public void SFXBar(float value)
    {
        _SFX_Rate.text = value.ToString() + '%';
        FindObjectOfType<AudioMixerController>().SetSFXVolume(value);
    }
}
