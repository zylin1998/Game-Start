using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("對話資料編號")]
    public string _dialogueID;

    public void TriggerDialogue() 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(_dialogueID);
    }
}
