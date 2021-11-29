using UnityEngine;

[System.Serializable]
public class Actions
{
    public string KeyName;
    public KeyCode KeyCode;
}

[CreateAssetMenu(fileName = "New Key Setting", menuName = "System Data/Key Setting", order = 1)]
public class KeyConfig : ScriptableObject
{
    public Actions[] _actions;
}