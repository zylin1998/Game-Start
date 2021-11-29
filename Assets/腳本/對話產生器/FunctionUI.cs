using UnityEngine;
using UnityEngine.UI;

public class FunctionUI : MonoBehaviour
{
    [Header("對話檔案")]
    public static Dialogue _dialogue;
    [Header("使用物件")]
    public GameObject _warning;
    public GameObject _charaSettingUI;
    public GameObject _dialogueSettingUI;
    public Dropdown _eventSelect;
    public Dropdown _charaSelect;
    public InputField _sentencID;
    public InputField _sentenceInput;
    public int select = 0;

    public void Initialized(string path)
    {
        _dialogue = (Dialogue)Resources.Load(path, typeof(Dialogue));

        _dialogue.charas = new Chara[0];
        _dialogue.sentences = new Sentence[0];
    }

    public void SetChara() 
    {
        if (!CheckFile()) { return; }

        _charaSettingUI.SetActive(true);
        _dialogueSettingUI.SetActive(false);
    }

    public void SettingFunctionSelect(int newValue) 
    {
        select = newValue;

        if(_dialogue == null || FindObjectOfType<DialogueSetting>().charas.Count <= 1) {
            _warning.SetActive(true);
            _warning.transform.Find("標題").GetComponent<Text>().text = "請先設定人物";
            return;
        }

        _charaSettingUI.SetActive(false);
        _dialogueSettingUI.SetActive(true);
        CheckInteractable();

    }

    private void CheckInteractable() 
    {
        _eventSelect.interactable = true;
        _sentencID.interactable = true;
        _charaSelect.interactable = true;
        _sentenceInput.interactable = true;

        if(select == 1)
        {
            _sentencID.interactable = false;
        }
        if(select == 3) 
        {
            _eventSelect.interactable = false;
            _charaSelect.interactable = false;
            _sentenceInput.interactable = false;
        }
    }

    private bool CheckFile() 
    {
        if(_dialogue == null) 
        {
            _warning.SetActive(true);
            _warning.transform.Find("標題").GetComponent<Text>().text = "請選擇檔案";

            return false;
        }
        else 
        {
            return true;
        }
    }

}
