using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public LayerMask roots;
    public Transform buildContainer;
    int index;
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentBuilding.Disable();
            index--;
            if (index < 0) index = buildContainer.childCount - 1;
            currentBuilding = buildContainer.GetChild(index).GetComponent<Building>();
            PlayerUI.instance.UpdateBuildingName(currentBuilding.name);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentBuilding.Disable();
            index++;
            if (index >= buildContainer.childCount) index = 0;
            currentBuilding = buildContainer.GetChild(index).GetComponent<Building>();
            PlayerUI.instance.UpdateBuildingName(currentBuilding.name);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Structure str in Structure.structures) str.Update();
        }
    }
}
