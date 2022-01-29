using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithTimer : MonoBehaviour
{
    public RectTransform rt;

    public void UpdateScale(float scale)
    {
        rt.anchorMin = new Vector2(1-scale, rt.anchorMin.y);

    }
}
