using UnityEngine;

[System.Serializable]
public class CGUsedData 
{
    public bool[] usedCG;

    public CGUsedData() 
    {
        usedCG = new bool[12];
    }

    public CGUsedData(CGData data) 
    {
        usedCG = new bool[data.CGs.Length];

        SetUsedCGs(data);
    }

    public void SetUsedCG(int num) 
    { 
        usedCG[num] = true; 
    }
    
    public void SetUsedCGs(CGData data) 
    { 
        for(int i = 0; i < data.CGs.Length; i++) { usedCG[i] = data.CGs[i].used; }
    }
}

[System.Serializable]
public class CG 
{
    public int page;
    public int id;
    public bool used;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "CG Data", menuName = "CG Data", order = 1)]
public class CGData : ScriptableObject
{
    public CG[] CGs;
}
