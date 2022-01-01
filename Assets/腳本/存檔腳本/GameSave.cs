using UnityEngine;

[System.Serializable]
public class GameSaveData 
{
    public float[] charaPosi;

    public bool[] jewelry;

    public bool[] letter;

    public GameSaveData()
    {
        charaPosi = new float[3];

        jewelry = new bool[3];

        letter = new bool[5];
    }

    public GameSaveData(float[] charaPosi, bool[] jewelry, bool[] letter)
    {
        this.charaPosi = charaPosi;

        this.jewelry = jewelry;

        this.letter = letter;
    }
}

[CreateAssetMenu(fileName = "GameSave", menuName = "System Data/Game Save", order = 1)]
public class GameSave : ScriptableObject
{
    public string loadFile;

    public float[] charaPosi;

    public bool[] jewelry;
    
    public bool[] letter;
    
    public GameSave() 
    {
        loadFile = "";
        charaPosi = new float[3];

        charaPosi[0] = 0;
        charaPosi[1] = 0;
        charaPosi[2] = 0;

        jewelry = new bool[3];

        letter = new bool[5];
    }

    public GameSave(string loadFile, float[] charaPosi, bool[] jewelry, bool[] letter)
    {
        this.loadFile = loadFile;
        this.charaPosi = charaPosi;

        this.jewelry = jewelry;

        this.letter = letter;
    }

    public void FoundNoSave(string loadFile) 
    {
        this.loadFile = loadFile;
        charaPosi = new float[3];

        charaPosi[0] = 14f;
        charaPosi[1] = 0.5f;
        charaPosi[2] = -16f;

        jewelry = new bool[3];

        letter = new bool[5];
    }

    public void FoundSave(string loadFile, float[] charaPosi, bool[] jewelry, bool[] letter)
    {
        this.loadFile = loadFile;
        this.charaPosi = charaPosi;

        this.jewelry = jewelry;

        this.letter = letter;
    }
}
