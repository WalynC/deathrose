using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitEffect : MonoBehaviour
{
    public UnityEvent hitEvent;

    public void Hit() { hitEvent?.Invoke(); }
}
