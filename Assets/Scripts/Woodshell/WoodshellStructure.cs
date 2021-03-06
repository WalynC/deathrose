using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodshellStructure : Structure
{
    public Root parent;
    int health = 10;

    public override void DealDamage(Vector3 vec)
    {
        if (obj.activeInHierarchy)
        {
            health--;
            if (health <= 0) Destroy();
        }
    }

    public override void Destroy()
    {
        parent?.structures.Remove(this);
        structures.Remove(this);
        obj.SetActive(false);
    }

    public override void Setup()
    {
        parent?.structures.Add(this);
        structures.Add(this);
    }

    public override void Update()
    {
        //woodshell is just a decoy
    }
}
