using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject prefab;
    Queue<GameObject> queue = new Queue<GameObject>();

    void CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        queue.Enqueue(obj);
    }

    public GameObject GetObject()
    {
        if (queue.Count == 0) CreateObject();
        return queue.Dequeue();
    }

    public void ReturnObject(GameObject obj)
    {
        queue.Enqueue(obj);
    }
}
