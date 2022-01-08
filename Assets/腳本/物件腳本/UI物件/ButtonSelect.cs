using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("初始選擇物件")]
    public UnityEvent _startGameObject;

    [Header("選擇中物件")]
    [SerializeField] private GameObject _nowGameObject;

    private EventSystem myEventSystem;
    
    private void Start()
    {
        _startGameObject.Invoke();

        myEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myEventSystem.SetSelectedGameObject(null);

        _nowGameObject = eventData.pointerEnter;

        SelectUI();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SelectUI();
    }

    public void PauseUI(bool pause) 
    {
        if (!pause) { this.enabled = false; }

        else 
        { 
            this.enabled = true;
            SelectUI();
        }
    }

    private void SelectUI() 
    {
        Button tempButton;
        Slider tempSlider;

        if (_nowGameObject.TryGetComponent<Button>(out tempButton)) 
        {
            tempButton.Select();
        }
        else if(_nowGameObject.TryGetComponent<Slider>(out tempSlider)) 
        {
            tempSlider.Select();
        }
        else if(_nowGameObject.GetComponentInParent<Button>() != null) 
        {
            tempButton = _nowGameObject.GetComponentInParent<Button>();
            tempButton.Select();
        }
    }
}

        /*Button temp;

        Debug.Log(eventData.pointerEnter.name);

        if(eventData.pointerEnter.TryGetComponent<Button>(out temp)) 
        {
            _nowButton = temp;
            _nowButton.Select();
        }
        else if(eventData.pointerEnter.GetComponentInParent<Button>() != null) 
        {
            temp = eventData.pointerEnter.GetComponentInParent<Button>();
            _nowButton = temp;
            _nowButton.Select();
        }*/