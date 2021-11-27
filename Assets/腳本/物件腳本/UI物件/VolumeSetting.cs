using UnityEngine;

[CreateAssetMenu(fileName = "Volume Setting", menuName = "System Data/Volume Setting", order = 1)]
public class VolumeSetting : ScriptableObject
{
    [Range(0, 100)]
    public int mainVolume;
    [Range(0, 100)]
    public int backgroundVolume;
    [Range(0, 100)]
    public int effectVolume;
}
