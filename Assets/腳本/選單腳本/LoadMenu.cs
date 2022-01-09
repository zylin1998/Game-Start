using UnityEngine;

public class LoadMenu : MonoBehaviour
{
    public static GameSave _gameSave;
    public static TargetScene _targetScene;

    private void Start()
    {
        _gameSave = (GameSave)Resources.Load(System.IO.Path.Combine("設定檔", "GameSave"), typeof(GameSave));
        if (_targetScene == null) { _targetScene = (TargetScene)Resources.Load(System.IO.Path.Combine("過場資料", "Target Scene"), typeof(TargetScene)); }
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
            _gameSave.FoundSave(fileName, gameSaveData.initialScene, gameSaveData.charaPosi, gameSaveData.jewelry, gameSaveData.letter);
        }

        _targetScene._sceneName = _gameSave.initialScene;
    }
}
