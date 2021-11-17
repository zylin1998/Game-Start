using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FirstSceneDialogue : MonoBehaviour
{
    public DialogueTrigger _dialogueTrigger;

    void Start()
    {
        _dialogueTrigger.GetComponent<DialogueTrigger>()._dialogueTXT = "Dialogue0001";
        _dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    private void Update()
    {
        if (FindObjectOfType<DialogueManager>().GetDialogueMode() == false) { ChangeScene(2); }
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
