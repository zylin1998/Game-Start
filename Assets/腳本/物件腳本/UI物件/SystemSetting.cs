using UnityEngine;

[System.Serializable]
public class ScreenSize 
{
    private string[,] windowSizes = { { "1280", "720" }, { "1920", "1080" } };

    public string ReturnStrSize(int select) 
    {
        string temp = windowSizes[select,0] + " x " + windowSizes[select,1];

        return temp;
    }

    public int[] ReturnIntSize(int select) 
    {
        int[] temp = { System.Convert.ToInt32(windowSizes[select, 0]), System.Convert.ToInt32(windowSizes[select, 1]) };

        return temp;
    }
}

[System.Serializable]
public class SystemConfig 
{
    public bool isFull;
    public int screenSize;

    [Range(0, 10)]
    public int textSpeed;
    [Range(0, 10)]
    public int autoSpeed;
    public bool skipOption;

    [Range(0, 100)]
    public int mainVolume;
    [Range(0, 100)]
    public int backgroundVolume;
    [Range(0, 100)]
    public int effectVolume;
}

[CreateAssetMenu(fileName = "SystemConfig", menuName = "Systen Data", order = 1)]
public class SystemSetting : ScriptableObject
{
    public SystemConfig systemConfig;

    public ScreenSize screenSize;
}
