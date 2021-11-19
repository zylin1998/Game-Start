using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform _displayParent;
    public Transform _ballParent;
    public Transform _letterParent;
    public GameObject _inventoryUI;
    public Text _detail;

    Inventory _inventory;

    InventorySlot _displaySlot;
    InventorySlot[] _ballSlots;
    InventorySlot[] _letterSlots;

    private void Start()
    {
        _inventory = Inventory.instance;
        _inventory.OnItemChangedCallback += UpdateUI;

        _displaySlot = _displayParent.GetComponentInChildren<InventorySlot>();
        _ballSlots = _ballParent.GetComponentsInChildren<InventorySlot>();
        _letterSlots = _letterParent.GetComponentsInChildren<InventorySlot>();
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

        foreach (InventorySlot slot in _letterSlots)
        {
            foreach (Item item in _inventory._letterList)
                if (item._name.Equals(slot._slotFor))
                {
                    slot.AddItem(item);
                    slot.CheckSlot();
                }
        }
    }

    public void Display(InventorySlot inventorySlot) {

        _displaySlot.AddItem(inventorySlot._item);

        _detail.text = inventorySlot._item._detail;
    
    }
}
