using UnityEngine;
using UnityEngine.UI;

public class GalleryMenu : MonoBehaviour
{
    [Header("CG欄位")]
    public Transform _cGParent;
    [Header("場景控制")]
    public LoadScenes _loadScenes;
    [Header("CG預覽")]
    public GameObject _cGDisplay;
    public static CGData _cGData;

    private Button[] _cGButton;
    private CGSlot[] _cGSlots;
    private Image _nowCG;
    

    private void Start()
    {
        _cGSlots = _cGParent.GetComponentsInChildren<CGSlot>();
        _cGButton = _cGParent.GetComponentsInChildren<Button>();
        _nowCG = _cGDisplay.GetComponent<Image>();

        if(_cGData == null) { _cGData = Resources.Load<CGData>(System.IO.Path.Combine("CG", "CG Data")); }
        
        Initialized();
    }

    private void Update()
    {
        DisplayChecked();
    }

    public void DisplayCG(CGSlot slot) 
    {
        _cGDisplay.SetActive(true);
        _nowCG.sprite = slot._sprite.sprite;
    }

    public void BackToTitle() 
    {
        _loadScenes.LoadNewScene("開始畫面");
        _loadScenes._asyncload.allowSceneActivation = true;
    }

    private void Initialized()
    {
        foreach (Button button in _cGButton)
        {
            button.enabled = false;
        }

        foreach (CG cg in _cGData.CGs) 
        { 
            foreach(CGSlot slot in _cGSlots) 
            {
                if (System.Convert.ToInt32(slot.ID) == cg.id && cg.used) 
                {
                    slot._sprite.sprite = _cGData.CGs[cg.id].sprite;
                    slot._sprite.color = Color.white;
                    _cGButton[cg.id].enabled = true;
                }
            }
        }
    }

    private void DisplayChecked() 
    {
        if (FindObjectOfType<KeyManager>()._escapeState) { _cGDisplay.SetActive(false); }
    }
}
