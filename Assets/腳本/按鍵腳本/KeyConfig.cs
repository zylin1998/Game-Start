using UnityEngine;

[System.Serializable]
public class Actions
{
    public string KeyName;
    public KeyCode KeyCode;
}

[CreateAssetMenu(fileName = "New Key Setting", menuName = "Create Data Asset", order = 1)]
public class KeyConfig : ScriptableObject
{
    public Actions[] _actions;
}