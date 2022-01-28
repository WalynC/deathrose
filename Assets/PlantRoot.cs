using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRoot : MonoBehaviour
{
    public GameObject prefab;
    
    public void CreateObject(Vector3 start, Vector3 end)
    {
        GameObject nGo = Instantiate(prefab);
        nGo.transform.position = (start + end)/2;
        nGo.transform.right = end - transform.position;
        nGo.transform.localScale = new Vector3(Vector3.Distance(start, end), 1, 1);
    }
}
