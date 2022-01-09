using UnityEngine;
using UnityEngine.UI;

public class PreviewContent : MonoBehaviour
{
    #region 欄位

    [Header("文本顯示")]
    public Text _text;
    [Header("文本資訊")]
    public Sentence _content;

    #endregion

    #region 內容輸入

    public void SetContent(Sentence sentence)
    {
        _content = new Sentence(sentence.type, sentence.id, sentence.chara, sentence.isRead, sentence.dialogue);

        PreviewText();
    }

    public void SetSimpleContent(Sentence sentence)
    {
        _content = new Sentence(sentence.type, sentence.id, sentence.chara, sentence.isRead, sentence.dialogue);

        PreviewSimpleText();
    }

    #endregion

    #region 文本格式建立及填充

    public void PreviewText()
    {
        string name;
        char[] dialogueType = { 'N', 'D', 'B' };

        if (_content.chara == 0) { name = "旁白"; }
        else { name = FindObjectOfType<ScrollList>().charas[_content.chara].name; }

        string preview = _content.id + " " + dialogueType[_content.type] + " " + name + "\n" + _content.dialogue;

        _text.text =  preview;
    }

    public void PreviewSimpleText() 
    {
        string name;
     
        if (_content.chara == 0) { name = "旁白"; }
        else { name = FindObjectOfType<ScrollList>().charas[_content.chara].name; }

        string preview = name + "\n" + _content.dialogue;

        _text.text = preview;
    }

    #endregion
}