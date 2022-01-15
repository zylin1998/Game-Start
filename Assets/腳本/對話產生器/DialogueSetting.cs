using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSetting : MonoBehaviour
{
    #region ���}���

    [Header("����ɮ�")]
    public static Dialogue _dialogue;
    [Header("�ϥΪ���")]
    public Dropdown _nameSelect;
    public Dropdown _typeSelect;
    public Dropdown _charaSelect;
    public int _charaCount;
    [Header("��ܹw��")]
    public GameObject preview1;
    public GameObject preview2;
    [Header("�Ȧs�M��")]
    public List<Chara> charas;
    public List<Sentence> sentences;

    #endregion

    #region �p�H���

    [SerializeField]
    private Sentence waitForCheck;
    private int _nowType;
    private int _nowID;
    private int _nowChara;

    #endregion

    #region �ƥ�

    private void Start()
    {
        charas = new List<Chara>();
        sentences = new List<Sentence>();
        waitForCheck = new Sentence();
    }

    #endregion

    #region ��l��

    public void Initialized(Dialogue dialogue)
    {
        _dialogue = dialogue;

        _nameSelect.options.Clear();
        preview1.GetComponent<ScrollList>().Initialized();
        
        Chara charaTemp = new Chara();
        charas.Add(charaTemp);

        Dropdown.OptionData dataTemp = new Dropdown.OptionData("�ǥ�");
        _nameSelect.options.Add(dataTemp);

        if(_dialogue.charas.Length > 0)
        { 
            foreach(Chara chara in _dialogue.charas) 
            {
                charaTemp = new Chara(chara.name, chara.posiX);
                dataTemp = new Dropdown.OptionData(chara.name);

                charas.Add(charaTemp);
                _nameSelect.options.Add(dataTemp);
            }

            SetCharas();
        }

        if (_dialogue.sentences.Length > 0)
        {
            foreach (Sentence sentence in _dialogue.sentences) 
            {
                Sentence temp = new Sentence(sentence.type, sentence.id, sentence.chara, false, sentence.dialogue, sentence.backGroundImage, sentence.sprite, sentence.ImageID);
                
                sentences.Add(temp);

                preview1.GetComponent<ScrollList>().IncreaseText(sentence);
            }
        }
    }

    #endregion

    #region �H���]�w

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

    #endregion

    #region �M��T�{

    private void CheckCharaList() 
    {
        if (_charaCount > charas.Count - 1) 
        {
            for(int i = charas.Count; i <= _charaCount; i++) 
            {
                Chara charaTemp = new Chara();
                Dropdown.OptionData optionData = new Dropdown.OptionData();
                optionData.text = "�H��" + i; 

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

    #endregion

    #region ��ܸ�ƿ�J

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

    public void DisplayBackGround(bool newValue) 
    {
        waitForCheck.backGroundImage = newValue;
    }

    public void DisplayCG(bool newValue) 
    {
        waitForCheck.sprite = newValue;
    }

    public void SetImageID(string newValue) 
    {
        waitForCheck.ImageID = System.Convert.ToInt32(newValue);
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

        waitForCheck = new Sentence(_nowType,_nowID, _nowChara, false, "");
    }

    #endregion

    #region ���s�H���M��

    private void ResetList() 
    {
        charas.Clear();
        _nameSelect.options.Clear();

        for(int i = 0; i <= _charaCount; i++) 
        {
            Chara charaTemp = new Chara();
            Dropdown.OptionData optionData = new Dropdown.OptionData();

            if (i == 0) { optionData.text = "�ǥ�"; }
            else { optionData.text = "�H��" + i; }

            charas.Add(charaTemp);
            _nameSelect.options.Add(optionData);
        }

        SetCharas();
    }

    #endregion

    #region ��X���

    public void SaveDialogue() 
    {
        Chara[] newCharas = new Chara[charas.Count - 1];
        Sentence[] newSentences = new Sentence[sentences.Count];

        for(int i = 0; i < charas.Count - 1; i++) 
        {
            Chara temp = new Chara(charas[i + 1].name, charas[i + 1].posiX);

            newCharas[i] = temp;
        }

        for (int i = 0; i < sentences.Count; i++)
        {
            Sentence temp = new Sentence(sentences[i].type, sentences[i].id, sentences[i].chara, false, sentences[i].dialogue, sentences[i].backGroundImage, sentences[i].sprite, sentences[i].ImageID);

            newSentences[i] = temp;
        }

        DialogueData data = new DialogueData(newCharas, newSentences);
        FindObjectOfType<OpenDialogue>().SaveDialogue(data);
    }

    #endregion

    #region �إ߹�ܤH���M��

    private void SetCharas() 
    {
        _charaSelect.options.Clear();

        foreach(Dropdown.OptionData data in _nameSelect.options) 
        {
            _charaSelect.options.Add(data);
        }

        FindObjectOfType<ScrollList>().charas = charas;
    }

    #endregion

    #region ��ܳ]�w

    private void AddSentence() 
    {
        waitForCheck.id = sentences.Count;

        sentences.Add(waitForCheck);

        preview1.GetComponent<ScrollList>().IncreaseText(sentences[sentences.Count - 1]);
    }

    private void InsertSentence() 
    {
        Sentence temp = new Sentence();
        sentences.Add(temp);

        for(int i = sentences.Count - 2; i >= waitForCheck.id; i--) 
        {
            sentences[i].id++;
            sentences[i + 1] = sentences[i];
            
            if(i == waitForCheck.id) 
            { 
                sentences[i] = waitForCheck;
                preview1.GetComponent<ScrollList>().InsertText(sentences[i]);
            }
        }
    }

    private void EditSentence() 
    {
        sentences[waitForCheck.id] = waitForCheck;

        preview1.GetComponent<ScrollList>().EditText(sentences[waitForCheck.id]);
    }

    private void RemoveSentence() 
    {
        sentences.RemoveAt(waitForCheck.id);

        for (int i = waitForCheck.id; i < sentences.Count; i++) 
        {
            if(sentences[i].id > waitForCheck.id) { sentences[i].id--; }
        }

        preview1.GetComponent<ScrollList>().RemoveText(waitForCheck.id);
    }

    #endregion
}