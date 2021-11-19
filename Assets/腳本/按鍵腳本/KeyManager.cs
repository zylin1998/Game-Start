using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public KeyConfig _keyConfig;

    public KeyConfig.Action[] _actions;

    public Text _eventHint;

    public Vector2 _direction = new Vector2(0, 0);
    public bool _jumpState = false;
    public bool _sprintState = false;
    public bool _eventState = false;
    public bool _inventoryState = false;
    public bool _escapeState = false;


    void Awake()
    {
        _keyConfig.ReadKeys();
        SetKeys();
    }

    void Update()
    {
        DirectionInput();
        JumpInput();
        SprintInput();
        EventInput();
        InventoryInput();
        Escape();
    }

    public void SetKeys()
    {
        _actions = _keyConfig.actions;
        _eventHint.text = _actions[6].KeyCode.ToString();
    }

    public void ResetKeys(KeyConfig.Action[] actions) { 
        _actions = actions;
        _keyConfig.WriteKeys(_actions);
    }

    public void DirectionInput()
    {

        if (Input.GetKeyDown(_actions[0].KeyCode)) { _direction.x++; }
        if (Input.GetKeyUp(_actions[0].KeyCode)) { _direction.x--; }

        if (Input.GetKeyDown(_actions[1].KeyCode)) { _direction.x--; }
        if (Input.GetKeyUp(_actions[1].KeyCode)) { _direction.x++; }

        if (Input.GetKeyDown(_actions[2].KeyCode)) { _direction.y--; }
        if (Input.GetKeyUp(_actions[2].KeyCode)) { _direction.y++; }

        if (Input.GetKeyDown(_actions[3].KeyCode)) { _direction.y++; }
        if (Input.GetKeyUp(_actions[3].KeyCode)) { _direction.y--; }

    }

    public void JumpInput()
    {
        if (Input.GetKeyDown(_actions[4].KeyCode)) { _jumpState = true; }
        else { _jumpState = false; }
    }

    public void SprintInput()
    {
        if (Input.GetKey(_actions[5].KeyCode)) { _sprintState = true; }
        else { _sprintState = false; }
    }

    public void EventInput()
    {
        if (Input.GetKey(_actions[6].KeyCode)) { _eventState = true; }
        else { _eventState = false; }
    }

    public void InventoryInput()
    {
        if (Input.GetKeyDown(_actions[7].KeyCode)) { _inventoryState = true; }
        else { _inventoryState = false; }
    }

    public void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { _escapeState = true; }
        else { _escapeState = false; }
    }
}