using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdrainBuilding : Building
{
    public LayerMask root;

    public override void Build()
    {
        Debug.Log("build");
    }

    public override void Preview()
    {
        buildable = false;
        RaycastHit rootHit;
        if (Physics.Raycast(CameraController.cam.ScreenPointToRay(Input.mousePosition), out rootHit, Mathf.Infinity, root))
        {
            position = RootNetwork.instance.GetClosestRootPoint(rootHit.point);
        }
    }
}
