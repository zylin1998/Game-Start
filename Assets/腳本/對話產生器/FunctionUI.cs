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

    public void Initialized(Dialogue dialogue)
    {
        _dialogue = dialogue;
    }

    public void SetChara() 
    {
        if (!CheckWarning()) { return; }

        _charaSettingUI.SetActive(true);
        _dialogueSettingUI.SetActive(false);
    }

    public void SettingFunctionSelect(int newValue) 
    {
        select = newValue;

        if(!CheckWarning()) { return; }

        _charaSettingUI.SetActive(false);
        _dialogueSettingUI.SetActive(true);
        CheckInteractable();

    }

    public void SaveButton() 
    {
        select = 5;
        if (!CheckWarning()) { return; }

        FindObjectOfType<DialogueSetting>().SaveDialogue();
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
        if(select == 4) 
        {
            _eventSelect.interactable = false;
            _charaSelect.interactable = false;
            _sentenceInput.interactable = false;
        }
    }

    private bool CheckWarning() 
    {
        if (_dialogue == null)
        {
            _warning.SetActive(true);
            _warning.transform.Find("標題").GetComponent<Text>().text = "請選擇檔案";

            return false;
        }

        else if (FindObjectOfType<DialogueSetting>().charas.Count <= 1 && select != 0) 
        {
            _warning.SetActive(true);
            _warning.transform.Find("標題").GetComponent<Text>().text = "請新增人物";
            select = 0;

            return false;
        }
        else if (FindObjectOfType<DialogueSetting>().sentences.Count <= 0 && select == 5) 
        {
            _warning.SetActive(true);
            _warning.transform.Find("標題").GetComponent<Text>().text = "請新增對話";
            select = 0;

            return false;
        }
        else
        {
            return true;
        }
    }
}
