using UnityEngine;
using UnityEngine.UI;

public class VolumeMenu : MonoBehaviour
{
    [Header("音量資訊")]
    public static VolumeSetting _volumeSetting;
    [Header("音量")]
    public Slider _mainVolume;
    public Slider _backgroundVolume;
    public Slider _effectVolume;
    public Text _mainVolumeText;
    public Text _backgroundVolumeText;
    public Text _effectVolumeText;

    private void Start()
    {
        if(_volumeSetting == null) { _volumeSetting = Resources.Load<VolumeSetting>(System.IO.Path.Combine("設定檔", "Volume Setting")); }

        Initialized();
    }

    public void ChangeMainVolume(float newValue)
    {
        _mainVolumeText.text = newValue.ToString();
        _volumeSetting.mainVolume = System.Convert.ToInt32(newValue);
        FindObjectOfType<AudioMixerController>().SetMainVolume(newValue);
    }

    public void ChangeBackgroundVolume(float newValue)
    {
        _backgroundVolumeText.text = newValue.ToString();
        _volumeSetting.backgroundVolume = System.Convert.ToInt32(newValue);
        FindObjectOfType<AudioMixerController>().SetBGMVolume(newValue);
    }

    public void ChangeEffectVolume(float newValue)
    {
        _effectVolumeText.text = newValue.ToString();
        _volumeSetting.effectVolume = System.Convert.ToInt32(newValue);
        FindObjectOfType<AudioMixerController>().SetSFXVolume(newValue);
    }
    private void Initialized() 
    {
        _mainVolume.value = _volumeSetting.mainVolume;
        _backgroundVolume.value = _volumeSetting.backgroundVolume;
        _effectVolume.value = _volumeSetting.effectVolume;

        ChangeMainVolume(_mainVolume.value);
        ChangeBackgroundVolume(_backgroundVolume.value);
        ChangeEffectVolume(_effectVolume.value);
    }
}
