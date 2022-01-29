using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure : IEnemyTarget
{
    public GameObject obj;
    public static List<Structure> structures = new List<Structure>();

    public abstract void Update();
    public abstract void Destroy();
    public abstract void Setup();
    public abstract void DealDamage(Vector3 vec);

    public static bool EnoughRoom(Vector3 position)
    {
        foreach (Structure str in structures)
        {
            if (Vector3.Distance(str.obj.transform.position, position) < 5f) return false;
        }
        return true;
    }
}
