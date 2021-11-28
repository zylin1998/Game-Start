using UnityEngine;
using UnityEngine.UI;

public class ScreenMenu : MonoBehaviour
{
    [Header("畫面資訊")]
    public static ScreenSetting _screenSetting;
    [Header("螢幕調整")]
    public Button[] _screenFull;
    public Button[] _screenSize;
    public Text _displaySize;
    public int _sizeSelect;

    private void Start()
    {
        if (_screenSetting == null) { _screenSetting = (ScreenSetting)Resources.Load(System.IO.Path.Combine("設定檔", "Screen Setting"), typeof(ScreenSetting)); }

        Initialized();
    }

    public void FullScreen(bool isFull)
    {
        _screenSetting.isFull = isFull;

        foreach (Button button in _screenFull)
        {
            button.image.color = Color.white;
            button.enabled = true;
        }

        if (isFull)
        {
            _screenFull[0].image.color = Color.gray;
            _screenFull[0].enabled = false;
        }
        else
        {
            _screenFull[1].image.color = Color.gray;
            _screenFull[1].enabled = false;
        }
    }

    public void ChangeScreenSize(int changed)
    {
        _sizeSelect += changed;
        _screenSetting.screenSize = _sizeSelect;
        ScreenSize(_sizeSelect);
    }

    private void Initialized() 
    {
        FullScreen(_screenSetting.isFull);

        _sizeSelect = _screenSetting.screenSize;
        ScreenSize(_sizeSelect);
    }

    private void ScreenSize(int screenSelect)
    {
        foreach (Button button in _screenSize)
        {
            button.image.color = Color.white;
            button.enabled = true;
        }

        if (screenSelect <= 0)
        {
            _screenSize[0].enabled = false;
            _screenSize[0].image.color = Color.gray;
        }
        else if (screenSelect >= 1)
        {
            _screenSize[1].enabled = false;
            _screenSize[1].image.color = Color.gray;
        }

        _displaySize.text = _screenSetting.ReturnStrSize(_sizeSelect);
    }
}
