using UnityEngine;

[CreateAssetMenu(fileName = "Text Setting", menuName = "System Data/Text Setting", order = 1)]
public class TextSetting : ScriptableObject
{
    [Range(0, 10)]
    public int textSpeed;
    [Range(0, 10)]
    public int autoSpeed;
    public bool skipOption;
}
