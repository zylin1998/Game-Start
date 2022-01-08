using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("物品欄位")]
    public Transform _ballParent;
    public Transform _letterParent;

    [Header("背包介面")]
    public GameObject _inventoryUI;
    public Transform[] _pages;

    [Header("資訊欄位")]
    public Text _jewelryDetail;
    public Text _letterDetail;

    Inventory _inventory;

    private InventorySlot[] _ballSlots;
    private SlotWithName[] _letterSlots;

    private void Start()
    {
        _inventory = Inventory.instance;
        _inventory.OnItemChangedCallback += UpdateUI;

        _ballSlots = _ballParent.GetComponentsInChildren<InventorySlot>();
        _letterSlots = _letterParent.GetComponentsInChildren<SlotWithName>();
    }

    private void Update()
    {
        if (FindObjectOfType<KeyManager>()._inventoryState) {
            _inventoryUI.SetActive(!_inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        foreach(InventorySlot slot in _ballSlots)
        {
            foreach(Item item in _inventory._ballList)
                if(item._name.Equals(slot._slotFor)) 
                { 
                    slot.AddItem(item);
                    slot.CheckSlot();
                }
        }

        foreach (SlotWithName slot in _letterSlots)
        {
            foreach (Item item in _inventory._letterList)
                if (item._name.Equals(slot._slotFor))
                {
                    slot.AddItem(item);
                    slot.CheckSlot();
                }
        }
    }

    public void DisplayJewel(InventorySlot inventorySlot)
    {
        _jewelryDetail.text = inventorySlot._item._detail;
    }

    public void DisplayLetter(SlotWithName inventorySlot)
    {
        _letterDetail.text = inventorySlot._item._detail;
    }

    public void TurnLeftPage() 
    {
        bool posiChange;

        foreach(Transform page in _pages) 
        {
            Debug.Log(page.localPosition.x);

            posiChange = false;

            if(!posiChange && page.localPosition.x == 1280) 
            { 
                page.localPosition = new Vector3(0, 0, 0);
                posiChange = true;
            }

            if(!posiChange && page.localPosition.x == 0) { page.localPosition = new Vector3(1280, 0, 0); }
        }
    }

    public void TurnRightPage()
    {
        bool posiChange;

        foreach (Transform page in _pages)
        {
            Debug.Log(page.localPosition.x);

            posiChange = false;

            if (!posiChange && page.localPosition.x == 1280)
            {
                page.localPosition = new Vector3(0, 0, 0);
                posiChange = true;
            }

            if (!posiChange && page.localPosition.x == 0) { page.localPosition = new Vector3(1280, 0, 0); }
        }
    }
}
