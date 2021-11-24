using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string _dialogueID;

    public void TriggerDialogue() 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(_dialogueID);
    }
}
