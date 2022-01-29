using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : IEnemyTarget
{
    Root parent;
    public List<Root> children = new List<Root>();
    public List<Structure> structures = new List<Structure>();
    float distanceFromParentStart;
    public float distance;
    public Vector3 start, end;
    GameObject visual;

    public Root(Vector3 s, Vector3 e, Root p, float d, GameObject v)
    {
        start = s;
        end = e;
        parent = p;
        distanceFromParentStart = d;
        distance = Vector3.Distance(s, e);
        visual = v;
        p?.children.Add(this);
    }

    public void DealDamage(Vector3 hit)
    {
        if (visual == null) return;
        if (children.Count > 0 || structures.Count > 0) return;
        if (Vector3.Distance(start, end) / Vector3.Distance(start, hit) < 1) return;
        float adjMagnitude = (end - start).magnitude - 1f;
        if (adjMagnitude < 0) Destroy();
        end = start + (end - start).normalized * adjMagnitude;
        RootNetwork.instance.PositionObject(visual, start, end);
    }

    public void Destroy()
    {
        parent?.children.Remove(this);
        RootNetwork.instance.roots.Remove(this);
        GameObject.Destroy(visual);
    }
}
