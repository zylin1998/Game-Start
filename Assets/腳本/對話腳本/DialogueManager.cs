using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region 公開欄位

    [Header("資料導入物件")]
    public static Dialogue _dialogue;
    public static TextSetting _textSetting;

    [Header("文字輸出物件")]
    public Text _nameText;
    public Text _dialogueText;

    [Header("對話狀態設定")]
    public bool _autoMode = false;
    public bool _skipMode = false;
    public bool _dialogueMode = false;

    private int _isSpeakChara;
    [Header("對話資料輸出")]
    public List<Chara> _charas;
    public Queue<Sentence> _sentences;
    public List<Sentence> _log;

    #endregion

    #region 事件

    private void Awake()
    {
        if(_textSetting == null) { _textSetting = (TextSetting)Resources.Load(Path.Combine("設定檔", "Text Setting"), typeof(TextSetting)); }
        if (_dialogue == null) { _dialogue = (Dialogue)Resources.Load(Path.Combine("對話資料", "Dialogue"), typeof(Dialogue)); }

        _sentences = new Queue<Sentence>();
        _log = new List<Sentence>();
    }

    #endregion

    #region 對話初始化

    public void StartDialogue(string ID) {

        //_dialogue = (Dialogue)Resources.Load(Path.Combine("對話資料", "Dialogue" + ID), typeof(Dialogue));

        GetFileName("Dialogue" + ID);

        _dialogueMode = true;
        FindObjectOfType<DialogueBoxController>().DialogueState(true);

        _charas.Clear();
        _sentences.Clear();
        _log.Clear();

        Chara temp = new Chara();
        temp.name = "";
        temp.posiX = 0;
        _charas.Add(temp);

        foreach (Chara chara in _dialogue.charas) { _charas.Add(chara); }
        foreach (Sentence sentence in _dialogue.sentences) { _sentences.Enqueue(sentence); }

        FindObjectOfType<DialogueSprite>().SetCharaSprite(_charas);

        DisplayNextSentence();
    }

    #endregion

    #region 顯示下段對話

    public void DisplayNextSentence() {
    
        if(_sentences.Count == 0) { 
            EndDialogue();
            return;
        }

        Sentence sentence = _sentences.Dequeue();
        _log.Add(sentence);

        if (sentence.backGroundImage && !sentence.sprite) 
        {
            FindObjectOfType<DialogueBoxController>().CGMode(sentence);
        }
        else if (sentence.backGroundImage && sentence.sprite)
        {
            FindObjectOfType<DialogueBoxController>().BackGroundMode(sentence);
        }
        else if (!sentence.backGroundImage && sentence.sprite)
        {
            FindObjectOfType<DialogueBoxController>().NormalizedMode(sentence);
        }

        _isSpeakChara = sentence.chara;
        _nameText.text = _charas[_isSpeakChara].name;
        FindObjectOfType<DialogueSprite>().DispalySprites(_isSpeakChara);

        if (_skipMode) { SkipModeTypeSentence(sentence.dialogue); }

        else if (!_skipMode)
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence.dialogue));
        }
    }

    private void SkipModeTypeSentence(string sentence) 
    {
        _dialogueText.text = "";
        _dialogueText.text += sentence;

        Invoke("DisplayNextSentence", 0.15f);
    }

    private IEnumerator TypeSentence(string sentence) 
    {
        _dialogueText.text = "";
        for(int i = 0; i < sentence.ToCharArray().Length; i++)
        {
            _dialogueText.text += sentence.ToCharArray()[i];
            yield return new WaitForSeconds(_textSetting.textSpeed * 0.02f);
        }

        if (_autoMode && !_skipMode) { Invoke("DisplayNextSentence", _textSetting.autoSpeed * 0.5f); }
    }

    public void Auto() 
    {
        if (_autoMode) { _autoMode = false; }

        else 
        {
            _autoMode = true;
            DisplayNextSentence();
        }
    }

    public void Skip() 
    {
        if (_skipMode) { _skipMode = false; }

        else
        {
            _skipMode = true;
            DisplayNextSentence();
        }
    }

    #endregion

    #region 文字預覽

    public void SetLogText() 
    {
        FindObjectOfType<ScrollList>().charas = _charas;
        FindObjectOfType<ScrollList>().Initialized();

        foreach (Sentence sentence in _log) 
        {
            FindObjectOfType<ScrollList>().IncreaseSimpleText(sentence);
        }
    }

    #endregion

    #region 結束對話

    public void EndDialogue() {

        _dialogueMode = false;

        _skipMode = false;

        FindObjectOfType<DialogueBoxController>().DialogueState(false);

    }

    #endregion

    #region 回傳資訊

    public bool GetDialogueMode() { return _dialogueMode; }

    public int GetIsSpeakChara() { return _isSpeakChara - 1; }

    #endregion

    #region 開啟對話資料

    private void GetFileName(string fileName)
    {
        string path = Path.Combine("DialogueData", fileName);

        string dialoguePath = Path.Combine(Application.dataPath, path + ".dialogue");

        if (File.Exists(dialoguePath))
        {
            _dialogue = SaveSystem.SetDefaultDialogue(dialoguePath);
        }

        else
        {
            Debug.Log("File Not Found.");
            EndDialogue();
        }

    }

    #endregion
}