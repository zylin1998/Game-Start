using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public GameObject _settingUI;
    public bool _isOpened = false;
    public Animator _animator;

    private void Start()
    {
        _animator.GetComponent<Animator>();
    }

    public void SetSettingUI()
    {
        _isOpened = !_isOpened;

        Setting();
    }

    public void Setting() 
    {
        _settingUI.SetActive(_isOpened);
        _animator.SetBool("isOpen", _isOpened);
    }
}
