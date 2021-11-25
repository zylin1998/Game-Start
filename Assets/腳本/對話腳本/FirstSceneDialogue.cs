using UnityEngine;

public class FirstSceneDialogue : MonoBehaviour
{
    public LoadScenes _loadScenes;
    public DialogueTrigger _dialogueTrigger;

    void Start()
    {
        _loadScenes.LoadNewScene("過場畫面");
        _dialogueTrigger.GetComponent<DialogueTrigger>()._dialogueID = "0001";
        _dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    private void Update()
    {
        if (FindObjectOfType<DialogueManager>().GetDialogueMode() == false) { Invoke("ChangeScene", 1f); }
    }

    public void ChangeScene()
    {
        _loadScenes._targetScene._sceneName = "開始任務";
        _loadScenes._asyncload.allowSceneActivation = true;
    }
}
