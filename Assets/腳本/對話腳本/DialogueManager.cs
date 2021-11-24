using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("資料導入物件")]
    public Dialogue _dialogue;

    [Header("文字輸出物件")]
    public Text _nameText;
    public Text _dialogueText;

    [Header("文字瀏覽速度設定")]
    [Range(0f, 0.10f)]
    public float _loadTextSpeed = 0f;
    [Range(0f,5f)]
    public float _autoSpeed = 5f;

    [Header("對話狀態設定")]
    public bool _autoMode = false;
    public bool _skipMode = false;
    public bool _dialogueMode = false;

    private int _isSpeakChara;
    public List<Chara> _charas;
    public Queue<Sentence> _sentences;
    public Queue<Sentence> _log;
   
    void Awake()
    {
        _sentences = new Queue<Sentence>();
        _log = new Queue<Sentence>();
    }

    public void StartDialogue(string ID) {

        _dialogue = (Dialogue)Resources.Load(System.IO.Path.Combine("對話資料", "Dialogue" + ID), typeof(Dialogue));

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

    public void DisplayNextSentence() {
    
        if(_sentences.Count == 0) { 
            EndDialogue();
            return;
        }

        Sentence sentence = _sentences.Dequeue();

        _isSpeakChara = sentence.chara;
        _nameText.text = _charas[_isSpeakChara].name;
        FindObjectOfType<DialogueSprite>().DispalySprites(_isSpeakChara);

        if (_skipMode) { SkipModeTypeSentence(sentence.dialogue); }

        else if (!_skipMode)
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence.dialogue));
        }

        //if (_autoMode && !_skipMode) { Invoke("DisplayNextSentence", _autoSpeed); }
    
    }

    private void SkipModeTypeSentence(string sentence) 
    {
        _dialogueText.text = "";
        _dialogueText.text += sentence;

        Invoke("DisplayNextSentence", 0.2f);
    }

    private IEnumerator TypeSentence(string sentence) 
    {
        _dialogueText.text = "";
        for(int i = 0; i < sentence.ToCharArray().Length; i++)
        {
            _dialogueText.text += sentence.ToCharArray()[i];
            yield return new WaitForSeconds(_loadTextSpeed);
        }

        if (_autoMode && !_skipMode) { Invoke("DisplayNextSentence", _autoSpeed); }
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

    public void EndDialogue() {

        _dialogueMode = false;
        FindObjectOfType<DialogueBoxController>().DialogueState(false);

    }

    public bool GetDialogueMode() { return _dialogueMode; }

    public int GetIsSpeakChara() { return _isSpeakChara - 1; }

}
