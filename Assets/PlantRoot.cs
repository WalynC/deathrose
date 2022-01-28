using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRoot : MonoBehaviour
{
    public GameObject prefab;
    public List<Root> roots = new List<Root>();

    public GameObject CreateObject(Vector3 start, Vector3 end)
    {
        GameObject nGo = Instantiate(prefab);
        nGo.transform.position = (start + end)/2;
        nGo.transform.right = end - start;
        nGo.transform.localScale = new Vector3(Vector3.Distance(start, end), 1, 1);
        return nGo;
    }

    public void CreateNewRoot(Vector3 end)
    {
        Root parent = null;
        Vector3 start = Vector3.zero;
        float dist = end.magnitude;
        for (int i = 0; i < roots.Count; ++i)
        {
            Root chRoot = roots[i];
            Vector3 challenge = ClosestPointOnLineSegment(roots[i].start, roots[i].end, end);
            float challengeDist = Vector3.Distance(challenge, end);
            if (challengeDist < dist)
            {
                dist = challengeDist;
                start = challenge;
                parent = chRoot;
            }
        }
        int price = (int)(dist * 10);
        if (PlayerMoney.instance.TryPurchase(price))
        {
            GameObject visual = CreateObject(start, end);
            float distAlong = parent != null ? dist / parent.distance : 0;
            Root root = new Root(start, end, parent, distAlong, visual);
            roots.Add(root);
            PlayerMoney.instance.ChangeMoneyCount(-price);
        }
        else Debug.Log("Cannot afford");
    }

    //found on https://stackoverflow.com/questions/3120357/get-closest-point-to-a-line
    public Vector3 ClosestPointOnLineSegment(Vector3 start, Vector3 end, Vector3 point)
    {
        Vector3 dirSP = point - start;
        Vector3 dirSE = end - start;

        float magnitude = dirSE.sqrMagnitude;
        float dirDot = Vector3.Dot(dirSP, dirSE);
        float dist = dirDot / magnitude;

        if (dist < 0) return start;
        else if (dist > 1) return end;
        else return start + dirSE * dist;
    }
}
