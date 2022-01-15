using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextMenu : MonoBehaviour
{
    [Header("��r��T")]
    public static TextSetting _textSetting;
    [Header("��r�t��")]
    public Slider _textSpeed;
    public Slider _autoSpeed;
    public Button[] _skipOption;
    public Text _textSpeedText;
    public Text _autoSpeedText;
    public Text _dialogueText;

    private void Start()
    {
        if (_textSetting == null) { _textSetting = Resources.Load<TextSetting>(System.IO.Path.Combine("�]�w��", "Text Setting")); }

        Initialized();
    }

    public void ChangeTextSpeed(float newValue)
    {
        _textSpeedText.text = newValue.ToString();
        _textSetting.textSpeed = System.Convert.ToInt32(newValue);

        DisplayDefaultSentence();
    }

    public void ChangeAutoSpeed(float newValue)
    {
        _autoSpeedText.text = newValue.ToString();
        _textSetting.autoSpeed = System.Convert.ToInt32(newValue);
    }

    public void SkipOption(bool isRead)
    {
        _textSetting.skipOption = isRead;

        foreach (Button button in _skipOption)
        {
            button.image.color = Color.white;
            button.enabled = true;
        }

        if (!isRead)
        {
            _skipOption[0].image.color = Color.gray;
            _skipOption[0].enabled = false;
        }
        else
        {
            _skipOption[1].image.color = Color.gray;
            _skipOption[1].enabled = false;
        }
    }

    private void Initialized() 
    {
        _textSpeed.value = _textSetting.textSpeed;
        _autoSpeed.value = _textSetting.autoSpeed;

        ChangeTextSpeed(_textSpeed.value);
        ChangeAutoSpeed(_autoSpeed.value);

        SkipOption(_textSetting.skipOption);
    }

    private void DisplayDefaultSentence()
    {
        //
        string _defaultSentence = "���o�A�аݹL�o�n�ܡH";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(_defaultSentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        _dialogueText.text = "";
        for (int i = 0; i < sentence.ToCharArray().Length; i++)
        {
            _dialogueText.text += sentence.ToCharArray()[i];
            yield return new WaitForSeconds(_textSetting.textSpeed * 0.02f);
        }
    }
}
