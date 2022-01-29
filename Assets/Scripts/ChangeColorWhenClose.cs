using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorWhenClose : MonoBehaviour
{
    public Material dead, alive;
    public MeshRenderer rend;

    private void Update()
    {
        Vector3 plantPos = RootNetwork.instance.GetClosestRootPoint(transform.position);
        if (Vector3.Distance(plantPos, transform.position) > 5f) rend.material = dead;
        else rend.material = alive;


    }
}
