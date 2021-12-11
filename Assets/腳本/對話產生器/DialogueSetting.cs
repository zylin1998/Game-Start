using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSetting : MonoBehaviour
{
    [Header("對話檔案")]
    public static Dialogue _dialogue;
    [Header("使用物件")]
    public Dropdown _nameSelect;
    public Dropdown _typeSelect;
    public Dropdown _charaSelect;
    public int _charaCount;
    [Header("對話預覽")]
    public GameObject preview1;
    public GameObject preview2;
    [Header("暫存清單")]
    public List<Chara> charas;
    public List<Sentence> sentences;
    public Sentence waitForCheck;
    public int _nowType;
    public int _nowID;
    public int _nowChara;

    private void Start()
    {
        charas = new List<Chara>();
        sentences = new List<Sentence>();
        waitForCheck = new Sentence();
    }

    public void Initialized(Dialogue dialogue)
    {
        _dialogue = dialogue;

        _nameSelect.options.Clear();
        
        Chara charaTemp = new Chara();
        charaTemp.name = "";
        charaTemp.posiX = 0;
        charas.Add(charaTemp);

        Dropdown.OptionData dataTemp = new Dropdown.OptionData();
        dataTemp.text = "旁白";
        _nameSelect.options.Add(dataTemp);

        if(_dialogue.charas.Length > 0)
        { 
            foreach(Chara chara in _dialogue.charas) 
            {
                charaTemp = new Chara();
                dataTemp = new Dropdown.OptionData();

                charaTemp.name = chara.name;
                charaTemp.posiX = chara.posiX;
                charas.Add(charaTemp);
                dataTemp.text = chara.name;
                _nameSelect.options.Add(dataTemp);
            }

            SetCharas();
        }

        if (_dialogue.sentences.Length > 0)
        {
            foreach (Sentence sentence in _dialogue.sentences) 
            {
                Sentence temp = new Sentence();
                temp.type = sentence.type;
                temp.id = sentence.id;
                temp.chara = sentence.chara;
                temp.dialogue = sentence.dialogue;
                sentences.Add(temp);

                string name;

                if (sentence.chara == 0) { name = "旁白"; }
                else { name = charas[sentence.chara].name; }

                string preview = name + "\n" + sentence.dialogue;

                FindObjectOfType<ScrollList>().IncreaseText(preview);
            }
        }
    }

    public void SetCharaCount(string newValue) 
    {
        if(newValue == "") { return; }

        _charaCount = System.Convert.ToInt32(newValue);

        if (charas.Count > 1) { CheckCharaList(); }

        else { ResetList(); }
    }

    public void NameSelect(int newValue) 
    {
        //Debug.Log(newValue + " + " + _charaSelect.value);
    }

    public void NameInput(string name) 
    {
        _nameSelect.options[_nameSelect.value].text = name;
        charas[_nameSelect.value].name = name;
    }

    public void PosiXInput(string posiX) 
    {
        if (posiX == "") { return; }

        charas[_nameSelect.value].posiX = System.Convert.ToInt32(posiX);
    }

    private void CheckCharaList() 
    {
        if (_charaCount > charas.Count - 1) 
        {
            for(int i = charas.Count; i <= _charaCount; i++) 
            {
                Chara charaTemp = new Chara();
                Dropdown.OptionData optionData = new Dropdown.OptionData();
                optionData.text = "人物" + i; 

                charas.Add(charaTemp);
                _nameSelect.options.Add(optionData);
            }
        }

        else if (_charaCount < charas.Count - 1) 
        {
            for(int i = charas.Count; i > _charaCount + 1; i--) 
            {
                charas.RemoveAt(i - 1);
                _nameSelect.options.RemoveAt(i - 1);
            }
        }

        SetCharas();
    }

    public void TypeSelect(int newValue) 
    {
        _nowType = newValue;
        waitForCheck.type = _nowType;
    }

    public void IDInput(string newValue) 
    {
        if(newValue == "") { return; }

        _nowID = System.Convert.ToInt32(newValue);
        waitForCheck.id = _nowID;
    }

    public void CharaSelect(int newValue) 
    {
        _nowChara = newValue;
        waitForCheck.chara = _nowChara;
    }

    public void DialogueInput(string dialogue) 
    {
        waitForCheck.dialogue = dialogue;
    }

    public void ConfirmButton() 
    {
        int select = FindObjectOfType<FunctionUI>().select;

        if(select == 1) { AddSentence(); }

        else if(select == 2) { InsertSentence(); }

        else if(select == 3) { EditSentence(); }

        else if(select == 4) { RemoveSentence(); }

        waitForCheck = new Sentence();

        waitForCheck.type = _nowType;
        waitForCheck.id = _nowID;
        waitForCheck.chara = _nowChara;
    }

    private void ResetList() 
    {
        charas.Clear();
        _nameSelect.options.Clear();

        for(int i = 0; i <= _charaCount; i++) 
        {
            Chara charaTemp = new Chara();
            Dropdown.OptionData optionData = new Dropdown.OptionData();

            if (i == 0) { optionData.text = "旁白"; }
            else { optionData.text = "人物" + i; }

            charas.Add(charaTemp);
            _nameSelect.options.Add(optionData);
        }

        SetCharas();
    }

    public void SaveDialogue() 
    {
        _dialogue.charas = new Chara[charas.Count - 1];
        _dialogue.sentences = new Sentence[sentences.Count];

        for(int i = 0; i < charas.Count - 1; i++) 
        {
            Chara temp = new Chara();

            temp.name = charas[i + 1].name;
            temp.posiX = charas[i + 1].posiX;

            _dialogue.charas[i] = temp;
        }

        for (int i = 0; i < sentences.Count; i++)
        {
            Sentence temp = new Sentence();

            temp.type = sentences[i].type;
            temp.id = sentences[i].id;
            temp.chara = sentences[i].chara;
            temp.dialogue = sentences[i].dialogue;

            _dialogue.sentences[i] = temp;
        }
    }

    private void SetCharas() 
    {
        _charaSelect.options.Clear();

        foreach(Dropdown.OptionData data in _nameSelect.options) 
        {
            Dropdown.OptionData temp = new Dropdown.OptionData();
            temp.text = data.text;

            _charaSelect.options.Add(data);
        }
    }

    private void AddSentence() 
    {
        waitForCheck.id = sentences.Count;

        sentences.Add(waitForCheck);

        string name;

        if (waitForCheck.chara == 0) { name = "旁白"; }
        else { name = charas[waitForCheck.chara].name; }

        string preview = name + "\n" + waitForCheck.dialogue;

        preview1.GetComponent<ScrollList>().IncreaseText(preview);
    }

    private void InsertSentence() 
    {
        Sentence temp = new Sentence();
        sentences.Add(temp);

        Debug.Log(sentences.Count);
        
        for(int i = sentences.Count - 2; i >= waitForCheck.id; i--) 
        {
            sentences[i].id++;
            sentences[i + 1] = sentences[i];

            if(i == waitForCheck.id) { sentences[i] = waitForCheck; }
        }

        if (waitForCheck.chara == 0) { name = "旁白"; }
        else { name = charas[waitForCheck.chara].name; }

        string preview = name + "\n" + waitForCheck.dialogue;

        FindObjectOfType<ScrollList>().InsertText(waitForCheck.id, preview);
    }

    private void EditSentence() 
    {
        sentences[waitForCheck.id] = waitForCheck;

        if (waitForCheck.chara == 0) { name = "旁白"; }
        else { name = charas[waitForCheck.chara].name; }

        string preview = name + "\n" + waitForCheck.dialogue;

        FindObjectOfType<ScrollList>().EditText(waitForCheck.id, preview);
    }

    private void RemoveSentence() 
    {
        sentences.RemoveAt(waitForCheck.id);

        for (int i = waitForCheck.id; i < sentences.Count; i++) 
        {
            if(sentences[i].id > waitForCheck.id) { sentences[i].id--; }
        }

        FindObjectOfType<ScrollList>().RemoveText(waitForCheck.id);
    }
}
