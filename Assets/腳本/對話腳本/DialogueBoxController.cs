using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxController : MonoBehaviour
{
    [Header("¹ï¸Ü®Ø±±¨î")]
    public Animator _animator;
    public GameObject _backGroundImage;
    public GameObject _charaSprite;

    private void Start()
    {
        _animator.GetComponent<Animator>();
        _backGroundImage.SetActive(false);
        _charaSprite.SetActive(false);
    }

    public void DialogueState(bool active)
    {
        _charaSprite.SetActive(active);
        _backGroundImage.SetActive(active);
        _animator.SetBool("IsOpen", active);
    }

    public void BoxClicked() 
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

}
