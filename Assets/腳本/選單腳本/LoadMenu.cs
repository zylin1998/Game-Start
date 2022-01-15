using UnityEngine;

public class LoadMenu : MonoBehaviour
{
    public static GameSave _gameSave;
    public static TargetScene _targetScene;

    private void Start()
    {
        _gameSave = Resources.Load<GameSave>(System.IO.Path.Combine("�]�w��", "GameSave"));
        if (_targetScene == null) { _targetScene = Resources.Load<TargetScene>(System.IO.Path.Combine("�L�����", "Target Scene")); }
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
            _gameSave.FoundSave(fileName, gameSaveData.initialScene, gameSaveData.isDialogueRead, gameSaveData.charaPosi, gameSaveData.jewelry, gameSaveData.letter);
        }

        _targetScene._sceneName = _gameSave.initialScene;
    }
}
