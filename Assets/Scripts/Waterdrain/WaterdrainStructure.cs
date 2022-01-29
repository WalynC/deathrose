using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdrainStructure : Structure
{
    public Root parent;
    public List<Water> waters = new List<Water>();
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
        List<Water> drained = new List<Water>();
        foreach (Water w in waters)
        {
            bool d = w.Drain(100);
            if (d) drained.Add(w);
        }
        foreach (Water d in drained)
        {
            waters.Remove(d);
        }
    }
}
