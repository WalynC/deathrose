using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodshellBuilding : Building
{
    public MeshRenderer preview;
    public LayerMask rootLayer;
    public Material canAfford, noAfford;
    public GameObject prefab;
    Root root;

    public override void Build()
    {
        if (!buildable) return;
        GameObject obj = Instantiate(prefab);
        obj.transform.position = position;
        WoodshellStructure struc = new WoodshellStructure();
        struc.parent = root;
        struc.obj = obj;
        struc.Setup();
        PlayerMoney.instance.ChangeMoneyCount(-price);
    }

    public override void Preview()
    {
        buildable = false;
        preview.gameObject.SetActive(false);
        RaycastHit rootHit;
        if (Physics.Raycast(CameraController.cam.ScreenPointToRay(Input.mousePosition), out rootHit, Mathf.Infinity, rootLayer))
        {
            position = RootNetwork.instance.GetClosestRootPoint(rootHit.point, out root);
            preview.gameObject.SetActive(root != null);
            preview.transform.position = position;
            if (PlayerMoney.instance.CanAfford(price))
            {
                buildable = true;
                preview.material = canAfford;
            }
            else
            {
                preview.material = noAfford;
            }
        }
        PlayerUI.instance.UpdateCostPreview(preview.gameObject.activeInHierarchy, price);
    }

    public override void Disable()
    {
        preview.gameObject.SetActive(false);
        PlayerUI.instance.UpdateCostPreview(preview.gameObject.activeInHierarchy, price);
        base.Disable();
    }
}
