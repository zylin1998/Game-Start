using UnityEngine;
using UnityEngine.UI;

public class PaintTrigger : MonoBehaviour
{
    [Header("事件按鈕")]
    public GameObject _hint;
    public Text _text;
    public GameObject image;
    public int _ID = 11;

    public static CGData _cGData;

    private bool _isOpen = false;

    [SerializeField] private CGUsedData _usedData;

    private void Start()
    {
        if (_cGData == null) { _cGData = Resources.Load<CGData>(System.IO.Path.Combine("CG", "CG Data")); }

        _usedData = SaveSystem.LoadCGUsedData();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (!_isOpen)
        {
            _hint.SetActive(true);
            _text.text = "查看";
        }

        if (FindObjectOfType<KeyManager>()._eventState && !_isOpen)
        {
            _isOpen = true;

            OpenImage();

            if (!_cGData.CGs[_ID].used)
            {
                _cGData.CGs[_ID].used = true;
                _usedData.SetUsedCG(_ID);
                SaveSystem.SaveCGUsedData(_usedData);
            }

            _hint.SetActive(false);
        }

        else if((FindObjectOfType<KeyManager>()._eventState || Input.GetKeyDown(KeyCode.Mouse0)) && _isOpen)
        {
            _isOpen = false;

            CloseImage();

            _hint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        _isOpen = false;

        CloseImage();

        _hint.SetActive(false);
    }

    private void OpenImage() 
    {
        image.SetActive(true);
        image.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        image.GetComponent<Image>().sprite = _cGData.CGs[_ID].sprite;
    }

    private void CloseImage() 
    {
        image.GetComponent<Image>().color = new Vector4(0, 0, 0, 145 / 255);
        image.GetComponent<Image>().sprite = null;
        image.SetActive(false);
    }
}
