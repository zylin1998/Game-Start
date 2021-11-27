using UnityEngine;
using UnityEngine.UI;

public class TextMenu : MonoBehaviour
{
    [Header("文字資訊")]
    public TextSetting _textSetting;
    [Header("文字速度")]
    public Slider _textSpeed;
    public Slider _autoSpeed;
    public Button[] _skipOption;
    public Text _textSpeedText;
    public Text _autoSpeedText;

    private void Start()
    {
        Initialized();
    }

    public void ChangeTextSpeed(float newValue)
    {
        _textSpeedText.text = newValue.ToString();
        _textSetting.textSpeed = System.Convert.ToInt32(newValue);
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
}
