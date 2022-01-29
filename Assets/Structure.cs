using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure
{
    public GameObject obj;
    public static List<Structure> structures = new List<Structure>();

    public abstract void Update();
    public abstract void Destroy();
    public abstract void Setup();
}
