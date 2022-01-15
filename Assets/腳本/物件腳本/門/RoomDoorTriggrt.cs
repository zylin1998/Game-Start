using UnityEngine;
using UnityEngine.UI;

public class RoomDoorTriggrt : MonoBehaviour
{
    [Header("�����")]
    public Animator _animator;
    [Header("�ƥ���s")]
    public GameObject _hint;
    public Text _text;
    [Header("�}�����A")]
    public bool _isOpened = false;

    private void OnTriggerStay(Collider collider)
    {
        if (!_isOpened) { _hint.SetActive(true); }
        _text.text = "�}��";

        if (FindObjectOfType<KeyManager>()._eventState)
        {
            _isOpened = true;
            _animator.SetBool("isOpen", true);
            Debug.Log("Door is Opened");
            _hint.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        _animator.SetBool("isOpen", false);
        _hint.SetActive(false);
        _isOpened = false;
    }

    public void SecretDoorTrigger() 
    {
        _animator.SetBool("isOpen", true);
    }
}
