using UnityEngine;
using UnityEngine.UI;

public class FunctionUI : MonoBehaviour
{
    #region 欄位

    [Header("對話檔案")]
    public static Dialogue _dialogue;
    [Header("使用物件")]
    public GameObject _warning;             //錯誤警告訊息
    public GameObject _charaSettingUI;      //人物設定介面
    public GameObject _dialogueSettingUI;   //對話設定介面
    public Dropdown _eventSelect;           //事件種類選項
    public Dropdown _charaSelect;           //人物種類選項
    public InputField _sentencID;           //對話編號輸入欄
    public InputField _sentenceInput;       //對話輸入欄
    public Toggle _backGround;
    public Toggle _sprite;
    public InputField _ImageID;
    public int select = 0;                  //功能選擇 1.新增 2.插入 3.編輯 4.刪除 5.儲存

    #endregion

    #region 初始化

    public void Initialized(Dialogue dialogue)
    {
        _dialogue = dialogue;
    }

    #endregion

    #region 開啟人物設定介面

    public void SetChara() 
    {
        if (!CheckWarning()) { return; }

        _charaSettingUI.SetActive(true);
        _dialogueSettingUI.SetActive(false);
    }

    #endregion

    #region 對話功能選擇

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

    #endregion

    #region 對話設定介面設置

    private void CheckInteractable() 
    {
        _eventSelect.interactable = true;
        _sentencID.interactable = true;
        _charaSelect.interactable = true;
        _sentenceInput.interactable = true;
        _backGround.interactable = true;
        _sprite.interactable = true;
        _ImageID.interactable = true;

        if(select == 1)
        {
            _sentencID.interactable = false;
        }
        if(select == 4) 
        {
            _eventSelect.interactable = false;
            _charaSelect.interactable = false;
            _sentenceInput.interactable = false;
            _backGround.interactable = false;
            _sprite.interactable = false;
            _ImageID.interactable = false;
        }
    }

    #endregion

    #region 警告種類選擇

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

    #endregion
}
