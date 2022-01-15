using UnityEngine;

[System.Serializable]
public class GameSaveData 
{
    public string initialScene;

    public float[] charaPosi;

    public bool[] isDialogueRead;

    public bool[] jewelry;

    public bool[] letter;

    public GameSaveData()
    {
        initialScene = "開頭";

        charaPosi = new float[3];

        isDialogueRead = new bool[12];

        jewelry = new bool[3];

        letter = new bool[5];
    }

    public GameSaveData(string initialScene, bool[] isDialogueRead,float[] charaPosi, bool[] jewelry, bool[] letter)
    {
        this.initialScene = initialScene;

        this.charaPosi = charaPosi;

        this.isDialogueRead = isDialogueRead;

        this.jewelry = jewelry;

        this.letter = letter;
    }
}

[CreateAssetMenu(fileName = "GameSave", menuName = "System Data/Game Save", order = 1)]
public class GameSave : ScriptableObject
{
    public string loadFile, initialScene;

    public float[] charaPosi;

    public bool[] isDialogueRead;

    public bool[] jewelry;
    
    public bool[] letter;
    
    public GameSave() 
    {
        loadFile = "";
        initialScene = "開頭";
        charaPosi = new float[3];

        charaPosi[0] = 0;
        charaPosi[1] = 0;
        charaPosi[2] = 0;

        isDialogueRead = new bool[12];

        jewelry = new bool[3];

        letter = new bool[5];
    }

    public GameSave(string loadFile,string initialScene, bool[] isDialogueRead, float[] charaPosi, bool[] jewelry, bool[] letter)
    {
        this.loadFile = loadFile;

        this.initialScene = initialScene;

        this.charaPosi = charaPosi;

        this.isDialogueRead = isDialogueRead;

        this.jewelry = jewelry;

        this.letter = letter;
    }

    public void FoundNoSave(string loadFile) 
    {
        this.loadFile = loadFile;
        initialScene = "開頭";

        charaPosi = new float[3];

        charaPosi[0] = 14f;
        charaPosi[1] = 0.5f;
        charaPosi[2] = -16f;

        isDialogueRead = new bool[12];

        jewelry = new bool[3];

        letter = new bool[5];
    }

    public void FoundSave(string loadFile, string initialScene, bool[] isDialogueRead, float[] charaPosi, bool[] jewelry, bool[] letter)
    {
        this.loadFile = loadFile;

        this.initialScene = initialScene;

        this.charaPosi = charaPosi;

        this.isDialogueRead = isDialogueRead;

        this.jewelry = jewelry;

        this.letter = letter;
    }
}
