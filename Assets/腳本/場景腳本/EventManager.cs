using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    #region ���}���

    public static GameSave _gameSave;
    public static TargetScene _targetScene;

    [Header("�������")]
    public Transform _itemParent;
    [Header("�ƥ󪫥�")]
    public GameObject[] _jewelry;
    public GameObject[] _letter;
    [Header("�ƥ󴣥�")]
    public GameObject _hint;
    public Text _text;

    #endregion

    #region �p�H���

    [Header("�ͦ�����")]
    [SerializeField] private GameObject[] _jewelrySet;
    [SerializeField] private GameObject[] _letterSet;

    [Header("�x�s���")]
    [SerializeField] private GameSaveData _gameSaveData;

    [SerializeField] private int _jewelryCount = 0;
    [SerializeField] private int _letterCount = 0;

    #endregion

    #region �ƥ�

    private void Awake()
    {
        _gameSave = Resources.Load<GameSave>(System.IO.Path.Combine("�]�w��", "GameSave"));
        if (_targetScene == null) { _targetScene = Resources.Load<TargetScene>(System.IO.Path.Combine("�L�����", "Target Scene")); }

        Initialized();
    }

    #endregion

    #region ��l��

    private void Initialized() 
    {
        GameObject.Find("�B�A").transform.position = new Vector3(_gameSave.charaPosi[0], _gameSave.charaPosi[1], _gameSave.charaPosi[2]);

        _jewelrySet = new GameObject[_gameSave.jewelry.Length];
        _letterSet = new GameObject[_gameSave.letter.Length];

        for (int i = 0;i < _gameSave.jewelry.Length; i++) 
        {
            if (!_gameSave.jewelry[i])
            {
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
                _jewelryCount++;
                if (_jewelryCount == 2) { GameObject.Find("�G�ӷt��").GetComponentInChildren<RoomDoorTriggrt>().SecretDoorTrigger(); }
                if (_jewelryCount == 3) { GameObject.Find("�@�ӷt��").GetComponentInChildren<RoomDoorTriggrt>().SecretDoorTrigger(); }
            }
        }

        for (int i = 0; i < _gameSave.letter.Length; i++)
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
                _letterCount++;
            }
        }

        _gameSave.initialScene = _targetScene._sceneName;
    }

    #endregion

    #region ��ܥHŪ�T�{

    public void SetReadDialogue(int isRead) 
    {
        if (isRead == 7) { DelayFinalScene(); }

        _gameSave.isDialogueRead[isRead - 1] = true;

        _gameSaveData = new GameSaveData(_gameSave.initialScene, _gameSave.isDialogueRead, _gameSave.charaPosi, _gameSave.jewelry, _gameSave.letter);

        SaveSystem.SaveGameSaveData(_gameSave.loadFile, _gameSaveData);
    }

    public bool GetReadDialogue(int isRead)
    {
        Debug.Log(_gameSave.isDialogueRead[isRead - 1]);

        return _gameSave.isDialogueRead[isRead - 1];
    }

    #endregion

    #region �B������

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

            _jewelryCount++;

            if(_jewelryCount == 2) 
            {
                FindObjectOfType<DialogueTrigger>()._dialogueID = "0011";
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
                GameObject.Find("�G�ӷt��").GetComponentInChildren<RoomDoorTriggrt>().SecretDoorTrigger();
            }
            else if (_jewelryCount == 3)
            {
                FindObjectOfType<DialogueTrigger>()._dialogueID = "0012";
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
                GameObject.Find("�@�ӷt��").GetComponentInChildren<RoomDoorTriggrt>().SecretDoorTrigger();
            }
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

            _letterCount++;
        }

        _gameSave.initialScene = _targetScene._sceneName;

        _gameSave.charaPosi[0] = GameObject.Find("�B�A").transform.position.x;
        _gameSave.charaPosi[1] = GameObject.Find("�B�A").transform.position.y;
        _gameSave.charaPosi[2] = GameObject.Find("�B�A").transform.position.z;

        _gameSaveData = new GameSaveData(_gameSave.initialScene, _gameSave.isDialogueRead, _gameSave.charaPosi, _gameSave.jewelry, _gameSave.letter);

        SaveSystem.SaveGameSaveData(_gameSave.loadFile, _gameSaveData);

        //Debug.Log("Data Saved.");

        Destroy(gameObject);
    }

    #endregion

    private void DelayFinalScene() 
    {
        Invoke("FinalScene", 0.5f);
    }

    private void FinalScene() 
    {
        LoadScenes._targetScene._sceneName = "����";
        FindObjectOfType<LoadScenes>().LoadNewScene("�L���e��");
        FindObjectOfType<LoadScenes>()._asyncload.allowSceneActivation = true;
    }
}