using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneDialogue : MonoBehaviour
{
    public LoadScenes _loadScenes;
    public DialogueTrigger _dialogueTrigger;
    public bool _endCheck = false;
    public string _dialogueID;
    
    void Start()
    {
        //Debug.Log(SceneManager.sceneCount);
        DisplayDialogue();
    }

    private void Update()
    {
        if (!_endCheck && FindObjectOfType<DialogueManager>().DialogueMode == false) { DelayChangeScene(); }
    }

    public void DelayDisplayDialogue()
    {
        Invoke("DisplayDialogue", 1f);
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

    public void DisplayDialogue() 
    {
        _dialogueTrigger.GetComponent<DialogueTrigger>()._dialogueID = _dialogueID;
        _dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();            
    }
}
