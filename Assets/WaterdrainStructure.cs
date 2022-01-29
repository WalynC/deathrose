using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdrainStructure : Structure
{
    public Root parent;
    public List<Water> waters = new List<Water>();

    public override void Destroy()
    {
        parent?.structures.Remove(this);
        structures.Remove(this);
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
