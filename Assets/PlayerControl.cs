using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public LayerMask ground, roots, wall;
    public Material canAfford, noAfford;
    public Building currentBuilding;

    private void Update()
    {
        currentBuilding.Preview();
        if (Input.GetMouseButtonDown(0)) //plant root
        {
            currentBuilding.Build();
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(CameraController.cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, roots))
            {
                CameraController.instance.transform.position = hit.point;
            }
        }
    }
}
