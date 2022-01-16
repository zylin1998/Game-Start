using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxController : MonoBehaviour
{
    [Header("¹ï¸Ü®Ø±±¨î")]
    public Animator _animator;
    public GameObject _backGroundImage;
    public GameObject _charaSprite;

    public static CGData _cGData;

    [SerializeField] private CGUsedData _usedData;

    private void Awake()
    {
        _animator.GetComponent<Animator>();
        _backGroundImage.SetActive(false);
        _charaSprite.SetActive(false);

        if (_cGData == null) { _cGData = (CGData)Resources.Load(System.IO.Path.Combine("CG", "CG Data"), typeof(CGData)); }

        _usedData = new CGUsedData(_cGData);
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

        if (!_cGData.CGs[sentence.ImageID].used) 
        {
            _cGData.CGs[sentence.ImageID].used = true;
            _usedData.SetUsedCG(sentence.ImageID);
            SaveSystem.SaveCGUsedData(_usedData);
        }

        _charaSprite.SetActive(false);
    }

    public void BackGroundMode(Sentence sentence)
    {
        Image image = _backGroundImage.GetComponent<Image>();

        image.sprite = _cGData.CGs[sentence.ImageID].sprite;
        image.color = new Vector4(1, 1, 1, 1);

        if (!_cGData.CGs[sentence.ImageID].used)
        {
            _cGData.CGs[sentence.ImageID].used = true;
            _usedData.SetUsedCG(sentence.ImageID);
            SaveSystem.SaveCGUsedData(_usedData);
        }

        _charaSprite.SetActive(true);
    }

    public void NormalizedMode(Sentence sentence) 
    {
        Image image = _backGroundImage.GetComponent<Image>();

        image.sprite = null;
        image.color = new Vector4(0, 0, 0, 145 / 255f);

        _charaSprite.SetActive(true);
    }

    public void ErrorBackGround(Sentence sentence) 
    {
        Image image = _backGroundImage.GetComponent<Image>();

        image.sprite = null;
        image.color = Color.blue;
    }

    public void BoxClicked() 
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

}
