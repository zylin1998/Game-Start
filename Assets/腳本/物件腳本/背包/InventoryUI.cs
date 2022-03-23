using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

    [Header("觸發事件")]
    public UnityEvent inventoryEvent;

    Inventory _inventory;

    private JewelrySlot[] _jewelrySlots;
    private LetterSlot[] _letterSlots;

    private void Awake()
    {
        _inventory = Inventory.instance;
        _inventory.OnItemChangedCallback += UpdateUI;

        _jewelrySlots = _ballParent.GetComponentsInChildren<JewelrySlot>();
        _letterSlots = _letterParent.GetComponentsInChildren<LetterSlot>();
    }

    void UpdateUI()
    {
        foreach(Item item in _inventory._itemList)
        {
            if(item._category == Category.jewelry) { AddJewelry(item); continue; }

            if(item._category == Category.letter) { AddLetter(item); continue; }
        }
    }

    public void AddJewelry(Item item) 
    {
        if(!(item as Jewelry)) { return; }

        Jewelry jewelry = item as Jewelry;

        foreach (JewelrySlot slot in _jewelrySlots) 
        { 
            if(jewelry.jewelryColor != slot.jewelryColor) { continue; }

            slot.AddItem(item);
            slot.CheckSlot();
        }
    }

    public void AddLetter(Item item)
    {
        if (!(item as Letter)) { return; }

        Letter letter = item as Letter;

        foreach (LetterSlot slot in _letterSlots)
        {
            if (letter._id != slot._id) { continue; }

            slot.AddItem(item);
            slot.CheckSlot();
        }
    }

    public void DisplayJewel(JewelrySlot slot)
    {
        _jewelryDetail.text = slot._item._detail;
    }

    public void DisplayLetter(LetterSlot slot)
    {
        _letterDetail.text = slot._item._detail;
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
