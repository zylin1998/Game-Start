using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    #region 公開欄位

    public static GameSave _gameSave;
    public static TargetScene _targetScene;

    [Header("物件欄位")]
    public Transform _itemParent;
    [Header("事件物件")]
    public GameObject[] _jewelry;
    public GameObject[] _letter;
    [Header("事件提示")]
    public GameObject _hint;
    public Text _text;

    #endregion

    #region 私人欄位

    [Header("生成物件")]
    [SerializeField] private GameObject[] _jewelrySet;
    [SerializeField] private GameObject[] _letterSet;

    [Header("儲存資料")]
    [SerializeField] private GameSaveData _gameSaveData;

    [SerializeField] private int _jewelryCount = 0;

    #endregion

    #region 事件

    private void Awake()
    {
        if (_gameSave == null) { _gameSave = Resources.Load<GameSave>(System.IO.Path.Combine("設定檔", "GameSave")); }
        if (_targetScene == null) { _targetScene = Resources.Load<TargetScene>(System.IO.Path.Combine("過場資料", "Target Scene")); }

        Initialized();
    }

    #endregion

    #region 初始化

    private void Initialized() 
    {
        GameObject.Find("翡翠").transform.position = new Vector3(_gameSave.charaPosi[0], _gameSave.charaPosi[1], _gameSave.charaPosi[2]);
        GameObject.Find("翡翠").transform.rotation = Quaternion.Euler(_gameSave.charaRotate[0], _gameSave.charaRotate[1], _gameSave.charaRotate[2]);

        _jewelrySet = new GameObject[_gameSave.jewelry.Length];
        _letterSet = new GameObject[_gameSave.letter.Length];

        for (int i = 0;i < _gameSave.jewelry.Length; i++) 
        {
            if (!_gameSave.jewelry[i]) { _jewelrySet[i] = SetGameObject(_jewelry[i]); continue; }

            if (_gameSave.jewelry[i])
            {
                Inventory.instance.Add(_jewelry[i].GetComponentInChildren<ItemPickup>()._item);
                _jewelryCount++;
                if (_jewelryCount == 2) { GameObject.Find("二樓暗門").GetComponentInChildren<RoomDoorTriggrt>().SecretDoorTrigger(); }
                if (_jewelryCount == 3) { GameObject.Find("一樓暗門").GetComponentInChildren<RoomDoorTriggrt>().SecretDoorTrigger(); }
            }
        }

        for (int i = 0; i < _gameSave.letter.Length; i++)
        {
            if (!_gameSave.letter[i]) { _letterSet[i] = SetGameObject(_letter[i]); continue; }
            
            if (_gameSave.letter[i]) { Inventory.instance.Add(_letter[i].GetComponentInChildren<ItemPickup>()._item); }
        }

        _gameSave.initialScene = _targetScene._sceneName;
    }

    private GameObject SetGameObject(GameObject gameObject) 
    {
        GameObject temp = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation, _itemParent);
        temp.name = gameObject.name;
        ItemPickup itemPickup = temp.GetComponentInChildren<ItemPickup>();
        itemPickup._hint = _hint;
        itemPickup._text = _text;

        return temp;
    }

    #endregion

    #region 對話以讀確認

    public void SetReadDialogue(int isRead) 
    {
        if (isRead == 7) { DelayFinalScene(); }

        _gameSave.isDialogueRead[isRead - 1] = true;

        _gameSaveData = new GameSaveData(_gameSave.initialScene, _gameSave.isDialogueRead, _gameSave.charaPosi, _gameSave.charaRotate, _gameSave.jewelry, _gameSave.letter);

        SaveSystem.SaveGameSaveData(_gameSave.loadFile, _gameSaveData);
    }

    public bool GetReadDialogue(int isRead)
    {
        Debug.Log(_gameSave.isDialogueRead[isRead - 1]);

        return _gameSave.isDialogueRead[isRead - 1];
    }

    #endregion

    #region 儲存資訊

    public void ItemPickUp(Item item) 
    {
        if (item._category == Category.jewelry) 
        {
            if (item is Jewelry jewelry) { ItemEvent(jewelry); }
        }

        if (item._category == Category.letter) 
        {
            if (item is Letter letter) { ItemEvent(letter); }
        }
    }

    private void ItemEvent(Jewelry jewelry) 
    {
        for (int i = 0; i < _jewelrySet.Length; i++)
        {
            if (_jewelrySet[i] == null) { continue; }

            Jewelry item = _jewelrySet[i].GetComponentInChildren<ItemPickup>()._item as Jewelry;

            if (jewelry.jewelryColor == item.jewelryColor)
            {
                _gameSave.jewelry[i] = true;
            }
        }

        _jewelryCount++;

        if (_jewelryCount == 2)
        {
            FindObjectOfType<DialogueTrigger>()._dialogueID = "0011";
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            GameObject.Find("二樓暗門").GetComponentInChildren<RoomDoorTriggrt>().SecretDoorTrigger();
        }
        
        if (_jewelryCount == 3)
        {
            FindObjectOfType<DialogueTrigger>()._dialogueID = "0012";
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            GameObject.Find("一樓暗門").GetComponentInChildren<RoomDoorTriggrt>().SecretDoorTrigger();
        }

        SaveEvent();
    }

    private void ItemEvent(Letter letter) 
    {
        for (int i = 0; i < _letterSet.Length; i++)
        {
            if (_letterSet[i] == null) { continue; }

            Letter item = _letterSet[i].GetComponentInChildren<ItemPickup>()._item as Letter;

            if (letter._id == item._id)
            {
                _gameSave.letter[i] = true;
            }
        }

        SaveEvent();
    }

    public void SaveEvent() 
    {
        _gameSave.initialScene = _targetScene._sceneName;

        _gameSave.charaPosi[0] = GameObject.Find("翡翠").transform.position.x;
        _gameSave.charaPosi[1] = GameObject.Find("翡翠").transform.position.y;
        _gameSave.charaPosi[2] = GameObject.Find("翡翠").transform.position.z;

        _gameSave.charaRotate[0] = GameObject.Find("翡翠").transform.rotation.x;
        _gameSave.charaRotate[1] = GameObject.Find("翡翠").transform.rotation.y;
        _gameSave.charaRotate[2] = GameObject.Find("翡翠").transform.rotation.z;

        _gameSaveData = new GameSaveData(_gameSave.initialScene, _gameSave.isDialogueRead, _gameSave.charaPosi, _gameSave.charaRotate, _gameSave.jewelry, _gameSave.letter);

        SaveSystem.SaveGameSaveData(_gameSave.loadFile, _gameSaveData);
    }

    #endregion

    private void DelayFinalScene() 
    {
        Invoke("FinalScene", 0.5f);
    }

    private void FinalScene() 
    {
        LoadScenes._targetScene._sceneName = "結尾";
        FindObjectOfType<LoadScenes>().LoadNewScene("過場畫面");
        FindObjectOfType<LoadScenes>()._asyncload.allowSceneActivation = true;
    }
}