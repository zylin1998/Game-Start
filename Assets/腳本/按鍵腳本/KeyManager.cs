using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [Header("按鍵資料引入")]
    public KeyConfig _actions;
    [Header("方向")]
    public Vector2Int _direction = new Vector2Int(0, 0);
    [Header("按鍵狀態")]
    public bool _jumpState = false;
    public bool _sprintState = false;
    public bool _eventState = false;
    public bool _inventoryState = false;
    [Header("跳脫狀態")]
    public bool _escapeState = false;
    public bool _actionsPause = false;

    private void Start()
    {
        if (_actions == null) { _actions = (KeyConfig)Resources.Load(System.IO.Path.Combine("設定檔","keys"), typeof(KeyConfig)); }
    }

    public void Update()
    {
        DirectionInput();
        JumpInput();
        SprintInput();
        EventInput();
        InventoryInput();
        Escape();
    }

    public void ResetKeys(Actions[] actions)
    {
        _actions._actions = actions;
    }

    private void DirectionInput()
    {
        if (!_actionsPause)
        {
            if (Input.GetKeyDown(_actions._actions[0].KeyCode)) { _direction.x++; }
            if (Input.GetKeyUp(_actions._actions[0].KeyCode)) { _direction.x--; }

            if (Input.GetKeyDown(_actions._actions[1].KeyCode)) { _direction.x--; }
            if (Input.GetKeyUp(_actions._actions[1].KeyCode)) { _direction.x++; }

            if (Input.GetKeyDown(_actions._actions[2].KeyCode)) { _direction.y--; }
            if (Input.GetKeyUp(_actions._actions[2].KeyCode)) { _direction.y++; }

            if (Input.GetKeyDown(_actions._actions[3].KeyCode)) { _direction.y++; }
            if (Input.GetKeyUp(_actions._actions[3].KeyCode)) { _direction.y--; }
        }
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(_actions._actions[4].KeyCode)) { _jumpState = true; }
        else { _jumpState = false; }
    }

    private void SprintInput()
    {
        if (Input.GetKey(_actions._actions[5].KeyCode)) { _sprintState = true; }
        else { _sprintState = false; }
    }

    private void EventInput()
    {
        if (Input.GetKey(_actions._actions[6].KeyCode)) { _eventState = true; }
        else { _eventState = false; }
    }

    private void InventoryInput()
    {
        if (Input.GetKeyDown(_actions._actions[7].KeyCode)) { _inventoryState = true; }
        else { _inventoryState = false; }
    }

    private void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _escapeState = true;
            _actionsPause = !_actionsPause;
        }
        else { _escapeState = false; }
    }

}