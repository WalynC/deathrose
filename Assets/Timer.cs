using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent elapsed;
    public ScaleWithTimer scale;

    public float timer = 20f;
    float time = 20f;

    private void OnEnable()
    {
        time = timer;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time > 0f) scale.UpdateScale(time/timer);
        if (time <= 0f) elapsed?.Invoke();
    }
}
