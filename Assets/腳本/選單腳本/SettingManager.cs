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

    void Update()
    {
        SetSettingUI();
    }

    private void SetSettingUI()
    {
        if (FindObjectOfType<KeyManager>()._escapeState && !_isOpened) 
        {
            _isOpened = true;
            _settingUI.SetActive(_isOpened);
            _animator.SetBool("isOpen", _isOpened);
        }

        else if(FindObjectOfType<KeyManager>()._escapeState && _isOpened)
        {
            _isOpened = false;
            _animator.SetBool("isOpen", _isOpened);
            Invoke("Setting", 0.5f);
        }

    }

    public void Setting() 
    {
        _settingUI.SetActive(_isOpened);
        FindObjectOfType<KeyManager>()._actionsPause = false;
    }

}
