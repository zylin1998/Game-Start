using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text _nameText;
    public Text _dialogueText;

    public bool _dialogueMode = false;

    public Animator _animator;

    private struct Sentence {

        public int id;
        public int chara;
        public string dialogue;    
    
    }

    private int _isSpeakChara;
    public List<Dialogue.Chara> _charas;
    private Queue<Sentence> _sentences;
   
    void Awake()
    {

        _sentences = new Queue<Sentence>();
        _charas = new List<Dialogue.Chara>();
        
    }

    public void StartDialogue(Dialogue dialogue) {

        _dialogueMode = true;
        _animator.SetBool("IsOpen", true);

        _charas.Clear();
        _sentences.Clear();

        foreach (Dialogue.Chara chara in dialogue._charas) { _charas.Add(chara); }
        foreach (string sentence in dialogue._sentences) { _sentences.Enqueue(SetSentence(sentence)); }

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

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence.dialogue));
    
    }

    IEnumerator TypeSentence(string sentence) {

        _dialogueText.text = "";
        for(int i = 0; i < sentence.ToCharArray().Length; i++){

            _dialogueText.text += sentence.ToCharArray()[i];
            yield return null;

        }
    
    }

    public void EndDialogue() {

        _dialogueMode = false;
        _animator.SetBool("IsOpen", false);

    }

    public bool GetDialogueMode() { return _dialogueMode; }

    public int GetIsSpeakChara() { return _isSpeakChara - 1; }

    private Sentence SetSentence(string sentence)
    {
        Sentence temp;

        string Id = "";
        string Name = "";
        string Dialogue = "";

        bool idCheck = false;
        bool nameCheck = false;
        bool dialogueCheck = false;

        foreach (char word in sentence)
        {
            if (word == '<') { idCheck = true; }

            else if (word == '>') { idCheck = false; }

            else if (word == '[') { nameCheck = true; }

            else if (word == ']') { nameCheck = false; }

            else if (word == '{') { dialogueCheck = true; }

            else if (word == '}') { dialogueCheck = false; }

            else if (idCheck) { Id += word; }

            else if (nameCheck) { Name += word; }

            else if (dialogueCheck) { Dialogue += word; }
        }

        temp.id = System.Convert.ToInt32(Id);
        temp.chara = System.Convert.ToInt32(Name);
        temp.dialogue = Dialogue;

        return temp;
    }

}
