using UnityEngine;

[CreateAssetMenu(fileName = "Screen Setting", menuName = "System Data/Screen Setting", order = 1)]
public class ScreenSetting : ScriptableObject
{
    private string[,] windowSizes = { { "1280", "720" }, { "1920", "1080" } };

    public bool isFull;
    public int screenSize;

    public string ReturnStrSize(int select)
    {
        string temp = windowSizes[select, 0] + " x " + windowSizes[select, 1];

        return temp;
    }

    public Vector2Int ReturnIntSize(int select)
    {
        Vector2Int temp = new Vector2Int(System.Convert.ToInt32(windowSizes[select, 0]), System.Convert.ToInt32(windowSizes[select, 1]));

        return temp;
    }
}
