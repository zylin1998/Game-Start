using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static GameSave _gameSave;

    [Header("物件欄位")]
    public Transform _itemParent;
    [Header("事件物件")]
    public GameObject[] _jewelry;
    public GameObject[] _letter;
    [Header("事件提示")]
    public GameObject _hint;
    public Text _text;

    [Header("生成物件")]
    [SerializeField] private GameObject[] _jewelrySet;
    [SerializeField] private GameObject[] _letterSet;

    [Header("儲存資料")]
    [SerializeField] private GameSaveData _gameSaveData;

    private int _jewelryCount;
    private int _letterCount;

    private void Start()
    {
        _gameSave = (GameSave)Resources.Load(System.IO.Path.Combine("設定檔", "GameSave"), typeof(GameSave));

        Initialized();
    }

    private void Update()
    {
        if (_gameSaveData.letter[4]) { /*結束遊戲*/ }
    }

    private void Initialized() 
    {
        GameObject.Find("翡翠").transform.position = new Vector3(_gameSave.charaPosi[0], _gameSave.charaPosi[1], _gameSave.charaPosi[2]);

        _jewelryCount = _gameSave.jewelry.Length;
        _letterCount = _gameSave.letter.Length;

        _jewelrySet = new GameObject[_jewelryCount];
        _letterSet = new GameObject[_letterCount];

        for (int i = 0;i < _jewelryCount; i++) 
        {
            if (!_gameSave.jewelry[i]) { 
                GameObject gameObject = Instantiate(_jewelry[i], _jewelry[i].transform.position, _jewelry[i].transform.rotation, _itemParent);
                gameObject.name = _jewelry[i].name;
                ItemPickup itemPickup = gameObject.GetComponentInChildren<ItemPickup>();
                itemPickup._hint = _hint;
                itemPickup._text = _text;
                _jewelrySet[i] = gameObject;
            }
            else 
            {
                Inventory.instance.Add(_jewelry[i].GetComponentInChildren<ItemPickup>()._item);
            }
        }

        for (int i = 0; i < _letterCount; i++)
        {
            if (!_gameSave.letter[i])
            {
                GameObject gameObject = Instantiate(_letter[i], _letter[i].transform.position, _letter[i].transform.rotation, _itemParent);
                gameObject.name = _letter[i].name;
                ItemPickup itemPickup = gameObject.GetComponentInChildren<ItemPickup>();
                itemPickup._hint = _hint;
                itemPickup._text = _text;
                _letterSet[i] = gameObject;
            }
            else
            {
                Inventory.instance.Add(_letter[i].GetComponentInChildren<ItemPickup>()._item);
            }
        }
    }

    public void ItemPickUp(GameObject gameObject) 
    {
        Item item = gameObject.GetComponentInChildren<ItemPickup>()._item;

        if (item._type.Equals("Ball")) 
        {
            for (int i = 0; i < _jewelrySet.Length; i++)
            {
                if (_jewelrySet[i] == null) { continue; }

                Item temp = _jewelrySet[i].GetComponentInChildren<ItemPickup>()._item;

                if (temp._name.Equals(item._name))
                {
                    _gameSave.jewelry[i] = true;
                }
            }

            _jewelryCount--;
        }

        else if (item._type.Equals("Letter")) 
        {
            for (int i = 0; i < _letterSet.Length; i++)
            {
                if(_letterSet[i] == null) { continue; }

                Item temp = _letterSet[i].GetComponentInChildren<ItemPickup>()._item;

                if (temp._name.Equals(item._name))
                {
                    _gameSave.letter[i] = true;
                }
            }

            _letterCount--;
        }

        _gameSave.charaPosi[0] = GameObject.Find("翡翠").transform.position.x;
        _gameSave.charaPosi[1] = GameObject.Find("翡翠").transform.position.y;
        _gameSave.charaPosi[2] = GameObject.Find("翡翠").transform.position.z;

        _gameSaveData = new GameSaveData(_gameSave.charaPosi, _gameSave.jewelry, _gameSave.letter);

        SaveSystem.SaveGameSaveData(_gameSave.loadFile, _gameSaveData);

        Debug.Log("Data Saved.");

        Destroy(gameObject);
    }
}