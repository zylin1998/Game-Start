using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSetting : MonoBehaviour
{
    [Header("對話檔案")]
    public static Dialogue _dialogue;
    [Header("使用物件")]
    public Dropdown _charaSelect;
    public int _charaCount;
    [Header("暫存清單")]
    public List<Chara> charas;
    public List<Sentence> sentences;

    private void Start()
    {
        charas = new List<Chara>();
        sentences = new List<Sentence>();
    }

    public void Initialized(string path)
    {
        _dialogue = (Dialogue)Resources.Load(path, typeof(Dialogue));

        _charaSelect.options.Clear();
        
        Chara charaTemp = new Chara();
        charaTemp.name = "";
        charaTemp.posiX = 0;
        charas.Add(charaTemp);

        Dropdown.OptionData dataTemp = new Dropdown.OptionData();
        dataTemp.text = "旁白";
        _charaSelect.options.Add(dataTemp);

        if(_dialogue.charas.Length > 0)
        { 
            foreach(Chara chara in _dialogue.charas) 
            { 
                charas.Add(chara);
                dataTemp.text = chara.name;
                _charaSelect.options.Add(dataTemp);
            }
        }

        if (_dialogue.sentences.Length > 0)
        {
            foreach (Sentence sentence in _dialogue.sentences) { sentences.Add(sentence); }
        }
    }

    public void SetCharaCount(string newValue) 
    {
        _charaCount = System.Convert.ToInt32(newValue);

        Debug.Log(charas.Count);

        if (charas.Count > 1) { CheckCharaList(); }

        else { ResetList(); }
    }

    public void CharaSelect(int newValue) 
    {
        //Debug.Log(newValue + " + " + _charaSelect.value);
    }

    public void NameInput(string name) 
    {
        _charaSelect.options[_charaSelect.value].text = name;
        charas[_charaSelect.value].name = name;
    }

    public void PosiXInput(string posiX) 
    {
        charas[_charaSelect.value].posiX = System.Convert.ToInt32(posiX);
    }

    private void CheckCharaList() 
    {
        if (_charaCount > charas.Count - 1) 
        {
            for(int i = charas.Count; i <= _charaCount + 1; i++) 
            {
                Chara charaTemp = new Chara();
                Dropdown.OptionData optionData = new Dropdown.OptionData();

                charas.Add(charaTemp);
                _charaSelect.options.Add(optionData);
            }
        }

        else if (_charaCount < charas.Count - 1) 
        {
            for(int i = charas.Count; i > _charaCount; i--) 
            {
                charas.RemoveAt(i);
                _charaSelect.options.RemoveAt(i);
            }
        }
    }

    private void ResetList() 
    {
        charas.Clear();
        _charaSelect.options.Clear();

        for(int i = 0; i <= _charaCount; i++) 
        {
            Chara charaTemp = new Chara();
            Dropdown.OptionData optionData = new Dropdown.OptionData();

            if (i == 0) { optionData.text = "旁白"; }
            else { optionData.text = "人物" + i; }

            charas.Add(charaTemp);
            _charaSelect.options.Add(optionData);
        }

    }
}
