using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRoot : MonoBehaviour
{
    public GameObject prefab;
    public List<Vector3> starts = new List<Vector3>();
    public List<Vector3> ends = new List<Vector3>();

    public void CreateObject(Vector3 start, Vector3 end)
    {
        GameObject nGo = Instantiate(prefab);
        nGo.transform.position = (start + end)/2;
        nGo.transform.right = end - start;
        nGo.transform.localScale = new Vector3(Vector3.Distance(start, end), 1, 1);
        starts.Add(start);
        ends.Add(end);
    }

    public void CreateNewRoot(Vector3 end)
    {
        Vector3 start = Vector3.zero;
        float dist = end.magnitude;
        for (int i = 0; i < starts.Count; ++i)
        {
            Vector3 challenge = ClosestPointOnLineSegment(starts[i], ends[i], end);
            float challengeDist = Vector3.Distance(challenge, end);
            if (challengeDist < dist)
            {
                dist = challengeDist;
                start = challenge;
            }
        }
        CreateObject(start, end);
    }

    //found on https://stackoverflow.com/questions/3120357/get-closest-point-to-a-line
    public Vector3 ClosestPointOnLineSegment(Vector3 start, Vector3 end, Vector3 point)
    {
        Vector3 dirSP = point - start;
        Vector3 dirSE = end - start;

        float magnitude = dirSE.magnitude;
        float dirDot = Vector3.Dot(dirSP, dirSE);
        float dist = dirDot / magnitude;

        if (dist < 0) return start;
        else if (dist > 1) return end;
        else return start + dirSE * dist;
    }
}
