using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [Header("設定選單")]
    public GameObject _settingMenu;
    public GameObject _basicSetting;
    public GameObject _keySetting;
    public Animator _animator;
    public Text _title;
    public Text _optionButton;
    public bool select = false;

    public void KeyConfig() 
    {
        string[] _buttonText = { "按鍵設定", "系統設定" };
        string temp;
        //Debug.Log("Coming Soon");
        select = !select;
        _basicSetting.SetActive(!_basicSetting.activeSelf);
        _keySetting.SetActive(!_keySetting.activeSelf);
        if (select) { temp = _buttonText[1]; }
        else { temp = _buttonText[0]; }
        _optionButton.text = temp;
    }

    public void BackToTitle() 
    {
        _animator.SetBool("isOpen", false);
        Invoke("CloseSettingMenu", 0.30f);
    }

    public void BackToTitleScene()
    {
        _animator.SetBool("isOpen", false);
        Invoke("GoStartMenu", 0.29f);
    }

    public void QuitGame() 
    { 
        Application.Quit();
    }

    private void CloseSettingMenu()
    {
        _settingMenu.SetActive(false);
    }

    private void GoStartMenu() 
    {
        FindObjectOfType<LoadScenes>().LoadNewScene("開始畫面");
        FindObjectOfType<LoadScenes>()._asyncload.allowSceneActivation = true;
    }
}
