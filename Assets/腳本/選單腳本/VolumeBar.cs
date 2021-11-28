using UnityEngine;
using UnityEngine.UI;

public class VolumeBar : MonoBehaviour
{
    [Header("音訊資料導入")]
    public static VolumeSetting _volumeSetting;
    [Header("音訊比例輸出")]
    public Text _main_Rate;
    public Text _BGM_Rate;
    public Text _SFX_Rate;

    private void Start()
    {
        if (_volumeSetting == null) { _volumeSetting = (VolumeSetting)Resources.Load(System.IO.Path.Combine("設定檔", "Volume Setting"), typeof(VolumeSetting)); }
    }

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
