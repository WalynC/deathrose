using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public BulletPool pool;
    int currentWave = 0;
    public static List<Enemy> burrowed = new List<Enemy>();
    public static List<Enemy> unburrowed = new List<Enemy>();

    void Start()
    {
        instance = this;
    }

    public void Deploy()
    {
        if (currentWave >= transform.childCount) return;
        Transform t = transform.GetChild(currentWave);
        for (int i = 0; i < t.childCount; ++i) {
            t.GetChild(i).gameObject.SetActive(true);
            Enemy e = t.GetChild(i).GetComponent<Enemy>();
            if (e != null)
            {
                e.BeginBurrow();
                burrowed.Add(e);
            }
        }
        currentWave++;
    }

    public void EnemyDefeated(Enemy e)
    {
        unburrowed.Remove(e);
        if (currentWave == transform.childCount && burrowed.Count == 0 && unburrowed.Count == 0)
        {
            GameState.instance.Win();
        }
    }
}
