using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Camera cam;
    public LayerMask ground, roots;
    public PlantRoot plRt;
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
            plRt.UpdatePreview(groundHit.point);
            plRt.preview.gameObject.SetActive(true);
            if (PlayerMoney.instance.CanAfford(plRt.previewPrice))
            {
                plRt.preview.material = canAfford;
                if (Input.GetMouseButtonDown(0)) //plant root
                {
                    plRt.CreateNewRoot(groundHit.point);
                }
            } else
            {
                plRt.preview.material = noAfford;
            }
        } else
        {
            plRt.preview.gameObject.SetActive(false);
            plRt.previewPrice = int.MaxValue;
        }
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
