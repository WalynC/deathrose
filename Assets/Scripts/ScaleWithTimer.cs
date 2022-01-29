using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithTimer : MonoBehaviour
{
    public RectTransform rt, rt2;

    public void UpdateScale(float scale)
    {
        rt.anchorMax = new Vector2(1 - scale, rt.anchorMax.y);
        rt2.anchorMin = new Vector2(1 - scale, rt2.anchorMin.y);

    }
}
