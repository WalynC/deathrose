using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Camera cam;
    public LayerMask ground, roots, wall;
    public Material canAfford, noAfford;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        RaycastHit groundHit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out groundHit, Mathf.Infinity, ground))
        {
            PlantRoot.instance.UpdatePreview(groundHit.point);
            PlantRoot.instance.preview.gameObject.SetActive(true);
            bool collision = Physics.Raycast(groundHit.point, 
                PlantRoot.instance.previewStart - groundHit.point, 
                PlantRoot.instance.preview.transform.localScale.x, 
                wall);
            if (PlayerMoney.instance.CanAfford(PlantRoot.instance.previewPrice) && PlantRoot.instance.previewPrice > 10 && !collision)
            {
                PlantRoot.instance.preview.material = canAfford;
                if (Input.GetMouseButtonDown(0)) //plant root
                {
                    PlantRoot.instance.CreateNewRoot(groundHit.point);
                }
            } else
            {
                PlantRoot.instance.preview.material = noAfford;
            }
        } else
        {
            PlantRoot.instance.preview.gameObject.SetActive(false);
            PlantRoot.instance.previewPrice = int.MaxValue;
        }
        PlayerUI.instance.UpdateCostPreview(PlantRoot.instance.preview.gameObject.activeInHierarchy);
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, roots))
            {
                CameraController.instance.transform.position = hit.point;
            }
        }
    }
}
