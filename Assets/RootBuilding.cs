using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootBuilding : Building
{
    public MeshRenderer preview;
    public LayerMask ground, roots, wall;
    public Material canAfford, noAfford;
    public Vector3 previewStart;

    public override void Build()
    {
        if (!buildable) return;
        PlantRoot.instance.CreateNewRoot(position);
        PlayerMoney.instance.ChangeMoneyCount(-price);
    }

    public void PositionObject(GameObject obj, Vector3 start, Vector3 end)
    {
        obj.transform.position = (start + end) / 2;
        obj.transform.right = end - start;
        obj.transform.localScale = new Vector3(Vector3.Distance(start, end), 1, 1);
    }

    public void UpdatePreview(Vector3 end)
    {
        previewStart = PlantRoot.instance.GetClosestRootPoint(end);
        PositionObject(preview.gameObject, previewStart, end);
        price = (int)(Vector3.Distance(previewStart, end) * 10);
    }

    public override void Preview()
    {
        buildable = false;
        RaycastHit groundHit;
        if (Physics.Raycast(CameraController.cam.ScreenPointToRay(Input.mousePosition), out groundHit, Mathf.Infinity, ground))
        {
            position = groundHit.point;
            UpdatePreview(position);
            preview.gameObject.SetActive(true);
            bool collision = Physics.Raycast(position, previewStart - position, preview.transform.localScale.x, wall);
            if (PlayerMoney.instance.CanAfford(price) && price > 10 && !collision)
            {
                buildable = true;
                preview.material = canAfford;
            } else
            {
                preview.material = noAfford;
            }
        } else
        {
            preview.gameObject.SetActive(false);
            price = int.MaxValue;
        }
        PlayerUI.instance.UpdateCostPreview(preview.gameObject.activeInHierarchy, price);
    }

    public override void Disable()
    {
        base.Disable();
    }
}
