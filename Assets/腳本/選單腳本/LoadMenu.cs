using UnityEngine;

public class LoadMenu : MonoBehaviour
{
    public static GameSave _gameSave;

    private void Start()
    {
        _gameSave = (GameSave)Resources.Load(System.IO.Path.Combine("≥]©w¿…", "GameSave"), typeof(GameSave));
    }

    public void GameLoaded(int loadCount)
    {
        string fileName = "load" + loadCount;

        GameSaveData gameSaveData = SaveSystem.LoadGameSaveData(fileName);

        if (gameSaveData == null) {
            Debug.Log("Have nothing to load.");
            _gameSave.FoundNoSave(fileName);
        }

        else 
        {
            Debug.Log(fileName + " is loaded.");
            _gameSave.FoundSave(fileName, gameSaveData.charaPosi, gameSaveData.jewelry, gameSaveData.letter);
        }
    }
}
