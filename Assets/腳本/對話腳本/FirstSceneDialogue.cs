using UnityEngine.SceneManagement;
using UnityEngine;

public class FirstSceneDialogue : MonoBehaviour
{
    public DialogueTrigger _dialogueTrigger;

    void Start()
    {
        _dialogueTrigger.GetComponent<DialogueTrigger>()._dialogueID = "0001";
        new WaitForSeconds(3f);
        _dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    private void Update()
    {
        if (FindObjectOfType<DialogueManager>().GetDialogueMode() == false) { Invoke("ChangeScene", 1f); }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("開始任務");
    }

}
