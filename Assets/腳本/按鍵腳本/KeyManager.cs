using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [Header("�����ƤޤJ")]
    public static KeyConfig _actions;
    [Header("��V")]
    public Vector2Int _direction = new Vector2Int(0, 0);
    [Header("���䪬�A")]
    public bool _jumpState = false;
    public bool _sprintState = false;
    public bool _eventState = false;
    public bool _inventoryState = false;
    [Header("���檬�A")]
    public bool _escapeState = false;
    public bool _actionsPause = false;

    private void Start()
    {
        if (_actions == null) { _actions = Resources.Load<KeyConfig>(System.IO.Path.Combine("�]�w��", "Keys")); }
    }

    private void Update()
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
        if (Input.GetKeyDown(_actions._actions[6].KeyCode)) { _eventState = true; }
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