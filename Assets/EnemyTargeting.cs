using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public float maxDist = 10f;
    public float timer = 1f;
    float time = 0f;

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time < timer) return;
        else
        {
            time -= timer;
        }
        //get closest structure
        Structure tgt = null;
        float curBest = maxDist;
        foreach (Structure s in Structure.structures)
        {
            float dist = Vector3.Distance(s.obj.transform.position, transform.position);
            if (dist <= curBest) {
                curBest = dist;
                tgt = s;
            }
        }
        if (tgt != null)
        {
            GameObject obj = EnemyManager.instance.pool.GetObject();
            Bullet bull = obj.GetComponent<Bullet>();
            obj.transform.position = transform.position;
            bull.Setup(tgt, tgt.obj.transform.position, EnemyManager.instance.pool);
            return;
        }
        //get closest root
        Root root = null;
        Vector3 hitPt = RootNetwork.instance.GetClosestRootPoint(transform.position, out root, true);
        if (root != null && Vector3.Distance(hitPt, transform.position) <= maxDist)
        {
            GameObject obj = EnemyManager.instance.pool.GetObject();
            Bullet bull = obj.GetComponent<Bullet>();
            obj.transform.position = transform.position;
            Debug.DrawRay(transform.position, hitPt - transform.position);
            bull.Setup(root, hitPt, EnemyManager.instance.pool);
            return;
        }
    }
}
