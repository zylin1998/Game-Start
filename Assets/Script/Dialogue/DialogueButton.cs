using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public void Continue() 
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    public void Skip() {

        Debug.Log("Skip pressed");

    }
}
