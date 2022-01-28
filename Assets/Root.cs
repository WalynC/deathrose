using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root
{
    Root parent;
    List<Root> children = new List<Root>();
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

    }
}
