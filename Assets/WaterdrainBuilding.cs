using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdrainBuilding : Building
{
    public LayerMask rootLayer, water;
    public MeshRenderer preview;
    public GameObject prefab;
    public Material canAfford, noWater, noAfford;
    Root root;
    float radius = 3;
    List<Water> waters = new List<Water>();

    public override void Build()
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = position;
        WaterdrainStructure struc = new WaterdrainStructure();
        foreach (Water w in waters) struc.waters.Add(w);
        struc.parent = root;
        struc.obj = obj;
        struc.Setup();
    }

    public override void Preview()
    {
        buildable = false;
        preview.gameObject.SetActive(false);
        waters.Clear();
        RaycastHit rootHit;
        if (Physics.Raycast(CameraController.cam.ScreenPointToRay(Input.mousePosition), out rootHit, Mathf.Infinity, rootLayer))
        {
            position = RootNetwork.instance.GetClosestRootPoint(rootHit.point, out root);
            preview.gameObject.SetActive(root != null);
            preview.transform.position = position;
            if (PlayerMoney.instance.CanAfford(price))
            {
                preview.material = canAfford;
                Collider[] colliders = Physics.OverlapSphere(position, radius, water);
                foreach (Collider c in colliders)
                {
                    Water w = c.GetComponent<Water>();
                    if (w != null) waters.Add(w);
                }
                if (waters.Count == 0) preview.material = noWater;
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
        PlayerUI.instance.UpdateCostPreview(preview.gameObject.activeInHierarchy, price);
        waters.Clear();
        base.Disable();
    }
}
