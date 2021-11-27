using UnityEngine;
using UnityEngine.UI;

public class CGSlot : MonoBehaviour
{
    public string ID;
    public GameObject _image;
    public Image _sprite;

    public void Start()
    {
        _sprite = _image.GetComponent<Image>();
    }
}
