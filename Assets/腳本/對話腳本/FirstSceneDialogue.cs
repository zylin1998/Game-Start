using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneDialogue : MonoBehaviour
{
    public LoadScenes _loadScenes;
    public DialogueTrigger _dialogueTrigger;
    public bool _endCheck = false;

    void Start()
    {
        //Debug.Log(SceneManager.sceneCount);
        _dialogueTrigger.GetComponent<DialogueTrigger>()._dialogueID = "0001";
        _dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    private void Update()
    {
        if (!_endCheck && FindObjectOfType<DialogueManager>().GetDialogueMode() == false) { DelayChangeScene(); }
    }

    public void DelayChangeScene() 
    {
        _endCheck = true;
        Invoke("ChangeScene", 1f);
    }

    public void ChangeScene()
    {
        LoadScenes._targetScene._sceneName = "開始任務";
        Debug.Log(SceneManager.GetActiveScene().name);
        _loadScenes.LoadNewScene("過場畫面");
        _loadScenes._asyncload.allowSceneActivation = true;
    }
}
