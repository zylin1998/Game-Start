using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxController : MonoBehaviour
{
    [Header("¹ï¸Ü®Ø±±¨î")]
    public Animator _animator;
    public GameObject _backGroundImage;
    public GameObject _charaSprite;

    public static CGData _cGData;

    private void Start()
    {
        _animator.GetComponent<Animator>();
        _backGroundImage.SetActive(false);
        _charaSprite.SetActive(false);

        if (_cGData == null) { _cGData = (CGData)Resources.Load(System.IO.Path.Combine("CG", "CG Data"), typeof(CGData)); }
    }

    public void DialogueState(bool active)
    {
        _charaSprite.SetActive(active);
        _backGroundImage.SetActive(active);
        _animator.SetBool("IsOpen", active);

        _backGroundImage.GetComponent<Image>().color = new Vector4(0, 0, 0, 145/255f);
    }

    public void CGMode(Sentence sentence) 
    {
        Image image = _backGroundImage.GetComponent<Image>();

        image.sprite = _cGData.CGs[sentence.ImageID].sprite;
        image.color = new Vector4(1, 1, 1, 1);

        _charaSprite.SetActive(false);
    }

    public void BackGroundMode(Sentence sentence)
    {
        Image image = _backGroundImage.GetComponent<Image>();

        image.sprite = _cGData.CGs[sentence.ImageID].sprite;
        image.color = new Vector4(1, 1, 1, 1);

        _charaSprite.SetActive(true);
    }

    public void NormalizedMode(Sentence sentence) 
    {
        Image image = _backGroundImage.GetComponent<Image>();

        image.sprite = null;
        image.color = new Vector4(0, 0, 0, 145 / 255f);

        _charaSprite.SetActive(true);
    }

    public void BoxClicked() 
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

}
