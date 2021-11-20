using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public GameObject[] _settingUI;
    public Button _backGround; 
    public bool _isOpened;

    void Start()
    {
        foreach(GameObject gameObject in _settingUI) { gameObject.GetComponent<GameObject>(); }
    }

    void Update()
    {
        SetSettingUI();
    }

    private void SetSettingUI()
    {
        foreach(GameObject gameObject in _settingUI) 
        {
            if (gameObject.activeSelf) { _isOpened = true; }
        }

        if(FindObjectOfType<KeyManager>()._escapeState && !_isOpened) 
        {
            _settingUI[0].SetActive(true);
            _settingUI[1].SetActive(true);
            _backGround.enabled = false;
        }

        else if(FindObjectOfType<KeyManager>()._escapeState && _isOpened)
        {
            EndSetting();
        }
    }

    public void EndSetting() 
    {
        foreach (GameObject gameObject in _settingUI)
        {
            gameObject.SetActive(false);
        }
        _backGround.enabled = true;

        _isOpened = false; 
    }

}
