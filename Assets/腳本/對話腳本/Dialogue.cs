using UnityEngine;

[System.Serializable]
public class Sentence
{
    public int type;
    public int id;
    public int chara;
    public string dialogue;
}

[System.Serializable]
public class Chara 
{
    public string name;
    public int posiX;
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Create Dialoue", order = 1)]
public class Dialogue : ScriptableObject
{
    public Chara[] charas;

    public Sentence[] sentences;
}