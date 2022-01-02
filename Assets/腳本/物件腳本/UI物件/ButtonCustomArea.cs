using UnityEngine;
using UnityEngine.UI;

public class ButtonCustomArea : MonoBehaviour
{
    [Header("可按區域透明度")]
    public float _touchedAlpha = 0.2f;

    private void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = _touchedAlpha;
    }
}