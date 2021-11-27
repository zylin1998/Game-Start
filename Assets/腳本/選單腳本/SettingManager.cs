using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public GameObject _settingUI;
    public bool _isOpened = false;

    void Update()
    {
        SetSettingUI();
    }

    private void SetSettingUI()
    {
        if (FindObjectOfType<KeyManager>()._escapeState && !_isOpened) 
        {
            _isOpened = true;
        }

        else if(FindObjectOfType<KeyManager>()._escapeState && _isOpened)
        {
            EndSetting();
        }

        _settingUI.SetActive(_isOpened);
    }

    public void EndSetting() 
    {
        _isOpened = false;

        FindObjectOfType<KeyManager>()._actionsPause = false;
    }

}
