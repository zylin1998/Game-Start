using UnityEngine;
using System.IO;

[System.Serializable]
public class SystemDataCollect 
{
    public bool isFull;
    public int sizeSelect;

    public int textSpeed;
    public int autoSpeed;
    public bool skipOption;

    public int mainVolume;
    public int backgroundVolume;
    public int effectVolume;

    public int front;
    public int back;
    public int left;
    public int right;
    public int jump;
    public int sprint;
    public int events;
    public int inventory;

    public void SetData(ScreenSetting screenSetting, TextSetting textSetting, VolumeSetting volumeSetting, KeyConfig keys)
    {
        screenSetting.isFull = isFull;
        screenSetting.screenSize = sizeSelect;

        textSetting.textSpeed = textSpeed;
        textSetting.autoSpeed = autoSpeed;
        textSetting.skipOption = skipOption;

        volumeSetting.mainVolume = mainVolume;
        volumeSetting.backgroundVolume = backgroundVolume;
        volumeSetting.effectVolume = effectVolume;

        keys._actions[0].KeyCode = (KeyCode)front;
        keys._actions[1].KeyCode = (KeyCode)back;
        keys._actions[2].KeyCode = (KeyCode)left;
        keys._actions[3].KeyCode = (KeyCode)right;
        keys._actions[4].KeyCode = (KeyCode)jump;
        keys._actions[5].KeyCode = (KeyCode)sprint;
        keys._actions[6].KeyCode = (KeyCode)events;
        keys._actions[7].KeyCode = (KeyCode)inventory;
    }

    public void GetData(ScreenSetting screenSetting, TextSetting textSetting, VolumeSetting volumeSetting, KeyConfig keys) 
    {
        isFull = screenSetting.isFull;
        sizeSelect = screenSetting.screenSize;

        textSpeed = textSetting.textSpeed;
        autoSpeed = textSetting.autoSpeed;
        skipOption = textSetting.skipOption;

        mainVolume = volumeSetting.mainVolume;
        backgroundVolume = volumeSetting.backgroundVolume;
        effectVolume = volumeSetting.effectVolume;

        front = System.Convert.ToInt32(keys._actions[0].KeyCode);
        back = System.Convert.ToInt32(keys._actions[1].KeyCode);
        left = System.Convert.ToInt32(keys._actions[2].KeyCode);
        right = System.Convert.ToInt32(keys._actions[3].KeyCode);
        jump = System.Convert.ToInt32(keys._actions[4].KeyCode);
        sprint = System.Convert.ToInt32(keys._actions[5].KeyCode);
        events = System.Convert.ToInt32(keys._actions[6].KeyCode);
        inventory = System.Convert.ToInt32(keys._actions[7].KeyCode);
    }

}

public class DataCollect : MonoBehaviour
{
    [Header("設定檔")]
    public static ScreenSetting _screenSetting;
    public static TextSetting _textSetting;
    public static VolumeSetting _volumeSetting;
    public static KeyConfig _keys;
    [Header("系統資料彙整")]
    public SystemDataCollect _systemDataCollect;

    private void Start()
    {
        if (_screenSetting == null) { _screenSetting = Resources.Load<ScreenSetting>(Path.Combine("設定檔", "Screen Setting")); }
        if (_textSetting == null) { _textSetting = Resources.Load<TextSetting>(Path.Combine("設定檔", "Text Setting")); }
        if (_volumeSetting == null) { _volumeSetting = Resources.Load<VolumeSetting>(Path.Combine("設定檔", "Volume Setting")); }
        if (_keys == null) { _keys = Resources.Load<KeyConfig>(Path.Combine("設定檔", "keys")); }

        SystemInitialized();
    }

    public void SaveSystemData() 
    {
        _systemDataCollect.GetData(_screenSetting, _textSetting, _volumeSetting, _keys);

        SaveSystem.SaveSystemData(_systemDataCollect);
    }

    private void SystemInitialized() 
    {
        _systemDataCollect = new SystemDataCollect();
        SystemDataCollect temp = SaveSystem.LoadSystemData();

        if(temp != null) {
            _systemDataCollect = temp;
            _systemDataCollect.SetData(_screenSetting, _textSetting, _volumeSetting, _keys);
        }
    }
}
