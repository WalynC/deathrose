using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdrainBuilding : Building
{
    public LayerMask root, water;
    public MeshRenderer preview;
    public Material canAfford, noWater, noAfford;
    int radius = 3;

    public override void Build()
    {
        Debug.Log("build");
    }

    public override void Preview()
    {
        buildable = false;
        preview.gameObject.SetActive(false);
        RaycastHit rootHit;
        if (Physics.Raycast(CameraController.cam.ScreenPointToRay(Input.mousePosition), out rootHit, Mathf.Infinity, root))
        {
            position = RootNetwork.instance.GetClosestRootPoint(rootHit.point);
            preview.gameObject.SetActive(true);
            preview.transform.position = position;
            if (PlayerMoney.instance.CanAfford(price))
            {
                preview.material = canAfford;
            } else
            {
                preview.material = noAfford;
            }
        }
        PlayerUI.instance.UpdateCostPreview(preview.gameObject.activeInHierarchy, price);
    }

    public override void Disable()
    {
        preview.gameObject.SetActive(false);
        base.Disable();
    }
}
