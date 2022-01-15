using UnityEngine;
using UnityEngine.UI;

public class ScreenMenu : MonoBehaviour
{
    [Header("�e����T")]
    public static ScreenSetting _screenSetting;
    [Header("�ù��վ�")]
    public Button[] _screenFull;
    public Button[] _screenSize;
    public Text _displaySize;
    public int _sizeSelect;

    private void Start()
    {
        if (_screenSetting == null) { _screenSetting = Resources.Load<ScreenSetting>(System.IO.Path.Combine("�]�w��", "Screen Setting")); }

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
            Screen.fullScreen = true;
        }
        else
        {
            _screenFull[1].image.color = Color.gray;
            _screenFull[1].enabled = false;
            Screen.fullScreen = false;
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
        Vector2Int screenSize;

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

        screenSize = _screenSetting.ReturnIntSize(screenSelect);

        Screen.SetResolution(screenSize.x, screenSize.y, _screenSetting.isFull);

        _displaySize.text = _screenSetting.ReturnStrSize(_sizeSelect);
    }
}
