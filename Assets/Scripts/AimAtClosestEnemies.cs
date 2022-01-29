using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtClosestEnemies : MonoBehaviour
{
    public Transform[] pivots;
    
    void Update()
    {
        List<Enemy> enemies = new List<Enemy>();
        foreach (Enemy e in EnemyManager.burrowed) enemies.Add(e);
        foreach (Enemy e in EnemyManager.unburrowed) enemies.Add(e);
        List<Enemy> sorted = new List<Enemy>();
        for (int x = 0; x < enemies.Count; ++x)
        {
            int j = 0;
            for (; j < sorted.Count && j < pivots.Length; ++j)
            {
                if (Vector3.Distance(RoseMovement.instance.transform.position, enemies[x].transform.position) < Vector3.Distance(RoseMovement.instance.transform.position, sorted[j].transform.position))
                {
                    break;
                }
            }
            sorted.Insert(j, enemies[x]);
        }
        int i = 0;
        for (; i < pivots.Length && i < sorted.Count; ++i)
        {
            pivots[i].gameObject.SetActive(true);
            Vector3 screenPos = CameraController.cam.WorldToScreenPoint(sorted[i].transform.position);
            screenPos.z = 0;
            pivots[i].right = screenPos - new Vector3(Screen.width, Screen.height) / 2f;

        }
        for (; i < pivots.Length; ++i)
        {
            pivots[i].gameObject.SetActive(false);
        }
    }
}
