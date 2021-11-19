using System.Collections;
using UnityEngine;

public class KeyInputManager : MonoBehaviour
{
    [Header("輸入按鈕欄位及動作輸入")]
    public Transform _keyParent;
    public KeyConfig.Action[] _actions;
    [Header("等待輸入及是否變動")]
    public bool _waitKey = false;
    public bool _isChanged = false;
    public KeyCode _newKeyCode;

    private Event _keyEvent;
    private KeyInputFeild[] _inputFeilds;

    void Start()
    {
        _inputFeilds = _keyParent.GetComponentsInChildren<KeyInputFeild>();
        _actions = FindObjectOfType<KeyManager>()._actions;

        KeyInitialize();
    }

    public void OnGUI()
    {
        _keyEvent = Event.current;

        if (_keyEvent.isKey && _waitKey)
        {
            if (_keyEvent.keyCode != 0) { _newKeyCode = _keyEvent.keyCode; }
            //Debug.Log(_newKeyCode);
            _waitKey = false;
        }

    }

    public void GetKey(string keyName) {

        foreach(KeyInputFeild feild in _inputFeilds) { feild._keyInput.enabled = false; }

        if (!_waitKey) { StartCoroutine(AssignKey(keyName)); }

    }

    IEnumerator WaitForKey()
    {
        while (!_keyEvent.isKey) { yield return null; }
    }

    public IEnumerator AssignKey(string keyName)
    {
        _waitKey = true;

        yield return WaitForKey();

        KeyChanged(keyName);

        yield return null;

    }

    public void SaveChanged() 
    {
        if (_isChanged) { FindObjectOfType<KeyManager>().ResetKeys(_actions); }

        _isChanged = false;
    }

    private void KeyInitialize() 
    {
        foreach (KeyInputFeild keyInputFeild in _inputFeilds)
        {
            foreach (KeyConfig.Action action in _actions) 
            {
                if (keyInputFeild._keyName.Equals(action.keyName)) 
                {
                    keyInputFeild._keyText.text = action.KeyCode.ToString();
                    keyInputFeild._nowKeyCode = action.KeyCode;
                }
            }
        }
    }

    private void KeyChanged(string keyNmame) 
    {
        int differ = 0;
        int same = 0;
        bool keyChange = false; 
        bool keySame = false;

        for (int i = 0; i < _actions.Length; i++)
        {
            if(keyNmame.Equals(_actions[i].keyName) && _newKeyCode != _actions[i].KeyCode) 
            { 
                keyChange = true;
                differ = i;
            }

            if(!keyNmame.Equals(_actions[i].keyName) && _newKeyCode == _actions[i].KeyCode) 
            { 
                keySame = true;
                same = i;
            }
        }

        //Debug.Log("NewKeyCode: " + _newKeyCode + " Differ: " + differ + " Same: " + same + " KeyChange: " + keyChange + " KeySame: " + keySame);

        if(keyChange && !keySame) 
        {
            _isChanged = true;

            _actions[differ].KeyCode = _newKeyCode;

            _inputFeilds[differ]._keyText.text = _newKeyCode.ToString();
            _inputFeilds[differ]._nowKeyCode = _newKeyCode;
        }

        else if(keyChange && keySame) 
        {
            _isChanged = true;

             KeyConfig.Action temp = _actions[differ];
            _actions[differ].KeyCode = _actions[same].KeyCode;
            _actions[same].KeyCode = temp.KeyCode;

             _inputFeilds[differ]._keyText.text = _actions[differ].KeyCode.ToString();
            _inputFeilds[differ]._nowKeyCode = _actions[differ].KeyCode;

            _inputFeilds[same]._keyText.text = _actions[same].KeyCode.ToString();
            _inputFeilds[same]._nowKeyCode = _actions[same].KeyCode;
        }

        foreach (KeyInputFeild feild in _inputFeilds) { feild._keyInput.enabled = true; }
    }

}
