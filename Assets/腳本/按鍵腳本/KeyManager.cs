using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public KeyConfig _keyConfig;

    public KeyCode _front;
    public KeyCode _back;
    public KeyCode _left;
    public KeyCode _right;
    public KeyCode _jump;
    public KeyCode _sprint;
    public KeyCode _event;
    public KeyCode _inventory;

    public Text _eventHint;

    public Vector2 _direction = new Vector2(0, 0);
    public bool _jumpState = false;
    public bool _sprintState = false;
    public bool _eventState = false;
    public bool _inventoryState = false;


    void Awake()
    {
        _keyConfig.action.ReadKeys();
        SetKeys();
    }

    void Update()
    {
        DirectionInput();
        JumpInput();
        SprintInput();
        EventInput();
        InventoryInput();
    }

    public void SetKeys()
    {

        _front = _keyConfig.action.front;
        _back = _keyConfig.action.back;
        _left = _keyConfig.action.left;
        _right = _keyConfig.action.right;
        _jump = _keyConfig.action.jump;
        _sprint = _keyConfig.action.sprint;
        _event = _keyConfig.action.events;
        _inventory = _keyConfig.action.inventory;

        _eventHint.text = _event.ToString();

    }

    public void DirectionInput()
    {

        if (Input.GetKeyDown(_front)) { _direction.x++; }
        if (Input.GetKeyUp(_front)) { _direction.x--; }

        if (Input.GetKeyDown(_back)) { _direction.x--; }
        if (Input.GetKeyUp(_back)) { _direction.x++; }

        if (Input.GetKeyDown(_left)) { _direction.y--; }
        if (Input.GetKeyUp(_left)) { _direction.y++; }

        if (Input.GetKeyDown(_right)) { _direction.y++; }
        if (Input.GetKeyUp(_right)) { _direction.y--; }

    }

    public void JumpInput()
    {
        if (Input.GetKeyDown(_jump)) { _jumpState = true; }
        else { _jumpState = false; }
    }

    public void SprintInput()
    {
        if (Input.GetKey(_sprint)) { _sprintState = true; }
        else { _sprintState = false; }
    }

    public void EventInput()
    {
        if (Input.GetKey(_event)) { _eventState = true; }
        else { _eventState = false; }
    }

    public void InventoryInput()
    {
        if (Input.GetKeyDown(_inventory)) { _inventoryState = true; }
        else { _inventoryState = false; }
    }
}