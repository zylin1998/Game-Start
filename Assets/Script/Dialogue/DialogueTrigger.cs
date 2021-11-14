using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string _dialogueTXT;
    public Dialogue _dialogue;

    public void TriggerDialogue() {

        _dialogue.SetContext(_dialogueTXT);
        FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
    
    }
}
