using UnityEngine;

#region 文本類別

[System.Serializable]
public class Sentence
{
    public Sentence() 
    {
        type = 0;
        type = 0;
        chara = 0;
        isRead = 0;
        dialogue = "";

        backGroundImage = false;
        sprite = false;
        ImageID = 0;
    }

    public Sentence(int type, int id, int chara, int isRead, string dialogue) 
    {
        this.type = type;
        this.id = id;
        this.chara = chara;
        this.isRead = isRead;
        this.dialogue = dialogue;

        backGroundImage = false;
        sprite = false;
        ImageID = 0;
    }

    public Sentence(int type, int id, int chara, int isRead, string dialogue, bool backGroundImage, bool sprite, int ImageID)
    {
        this.type = type;
        this.id = id;
        this.chara = chara;
        this.isRead = isRead;
        this.dialogue = dialogue;

        this.backGroundImage = backGroundImage;
        this.sprite = sprite;
        this.ImageID = ImageID;
    }

    public int id;
    public int type;
    public int chara;
    public int isRead;
    public string dialogue;

    public bool backGroundImage;
    public bool sprite;
    public int ImageID;
}

#endregion

#region 人物類別

[System.Serializable]
public class Chara
{
    public Chara() 
    {
        name = "";
        posiX = 0;
    }

    public Chara(string name, int posiX)
    {
        this.name = name;
        this.posiX = posiX;
    }

    public string name;
    public int posiX;
}

#endregion

#region 儲存用對話類別

[System.Serializable]
public class DialogueData
{
    public DialogueData() { }

    public DialogueData(Chara[] charas, Sentence[] sentences) 
    { 
        this.charas = charas;
        this.sentences = sentences;
    }

    public Chara[] charas;

    public Sentence[] sentences;
}

#endregion

#region 使用中對話

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public Dialogue() { }

    public Dialogue(Chara[] charas, Sentence[] sentences) 
    {
        this.charas = charas;
        this.sentences = sentences;
    }

    public Chara[] charas;

    public Sentence[] sentences;
}

#endregion