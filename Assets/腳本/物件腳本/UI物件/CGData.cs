using UnityEngine;

[System.Serializable]
public class CG 
{
    public int page;
    public int id;
    public bool used;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "CG Data", menuName = "Create CG Data", order = 1)]
public class CGData : ScriptableObject
{
    public CG[] CGs;
}
