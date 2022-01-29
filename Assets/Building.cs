using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public bool buildable;
    public int price;
    public Vector3 position;

    public abstract void Preview();
    public abstract void Build();
    public virtual void Disable()
    {
        buildable = false;
        position = Vector3.zero;
    }
}
