using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public IEnemyTarget target;
    public BulletPool pool;
    float dist = 0f;
    Vector3 startPos, aimPos, dir;

    public void Setup(IEnemyTarget t, Vector3 a, BulletPool p)
    {
        target = t;
        aimPos = a;
        pool = p;
        startPos = transform.position;
        gameObject.SetActive(true);
        if (target != null) dist = Vector3.Distance(startPos, aimPos);
        dir = (aimPos - startPos).normalized;
    }

    private void FixedUpdate()
    {
        transform.Translate(dir * 10f * Time.deltaTime);
        if (target != null && Vector3.Distance(startPos, transform.position) > dist)
        {
            target.DealDamage(aimPos);
            target = null;
            pool.ReturnObject(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pool.ReturnObject(gameObject);
        gameObject.SetActive(false);
        target = null;
    }
}
