using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region ���}���

    [Header("��ƾɤJ����")]
    public static Dialogue _dialogue;
    public static TextSetting _textSetting;

    [Header("��r��X����")]
    public Text _nameText;
    public Text _dialogueText;

    [Header("��ܪ��A�]�w")]
    public bool _autoMode = false;
    public bool _skipMode = false;
    public bool _dialogueMode = false;

    private int _isSpeakChara;
    [Header("��ܸ�ƿ�X")]
    public List<Chara> _charas;
    public Queue<Sentence> _sentences;
    public List<Sentence> _log;

    public Text _imageMode;

    [SerializeField] private string _fileName;
    [SerializeField] private int _ID;

    #endregion

    #region �ƥ�

    private void Awake()
    {
        if(_textSetting == null) { _textSetting = Resources.Load<TextSetting>(Path.Combine("�]�w��", "Text Setting")); }
        if (_dialogue == null) { _dialogue = Resources.Load<Dialogue>(Path.Combine("��ܸ��", "Dialogue")); }

        _sentences = new Queue<Sentence>();
        _log = new List<Sentence>();
    }

    #endregion

    #region ��ܪ�l��

    public void StartDialogue(string ID) 
    {
        Cursor.lockState = CursorLockMode.Confined;

        _fileName = "Dialogue" + ID;
        _ID = System.Convert.ToInt32(ID);

        GetFileName(_fileName);

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

    #region ��ܤU�q���

    public void DisplayNextSentence() {
    
        if(_sentences.Count == 0) { 
            EndDialogue();
            return;
        }

        Sentence sentence = _sentences.Dequeue();
        _log.Add(sentence);

        if (sentence.backGroundImage && !sentence.sprite) 
        {
            _imageMode.text = "1";
            FindObjectOfType<DialogueBoxController>().CGMode(sentence);
        }
        else if (sentence.backGroundImage && sentence.sprite)
        {
            _imageMode.text = "2";
            FindObjectOfType<DialogueBoxController>().BackGroundMode(sentence);
        }
        else if (!sentence.backGroundImage && sentence.sprite)
        {
            _imageMode.text = "3";
            FindObjectOfType<DialogueBoxController>().NormalizedMode(sentence);
        }

        _isSpeakChara = sentence.chara;
        _nameText.text = _charas[_isSpeakChara].name;
        FindObjectOfType<DialogueSprite>().DispalySprites(_isSpeakChara);

        _dialogue.sentences[sentence.id].isRead = true;
        
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

    #region ��r�w��

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

    #region �������

    public void EndDialogue() 
    {
        _dialogueMode = false;

        _skipMode = false;

        FindObjectOfType<DialogueBoxController>().DialogueState(false);

        if (FindObjectOfType<EventManager>() != null) 
        {
            FindObjectOfType<EventManager>().SetReadDialogue(_ID); 
        }

        DialogueData dialogueData = new DialogueData(_dialogue.charas, _dialogue.sentences);

        SaveSystem.SaveDialogueData(_fileName, dialogueData);
    }

    #endregion

    #region �^�Ǹ�T

    public bool GetDialogueMode() { return _dialogueMode; }

    public int GetIsSpeakChara() { return _isSpeakChara - 1; }

    #endregion

    #region �}�ҹ�ܸ��

    public void GetFileName(string fileName)
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