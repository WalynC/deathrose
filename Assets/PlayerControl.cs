using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Camera cam;
    public LayerMask ground, roots;
    public PlantRoot plRt;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        RaycastHit groundHit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out groundHit, Mathf.Infinity, ground))
        {
            plRt.PositionObject(plRt.preview, plRt.GetClosestRootPoint(groundHit.point), groundHit.point);
            plRt.preview.SetActive(true);
            if (Input.GetMouseButtonDown(0)) //plant root
            {
                plRt.CreateNewRoot(groundHit.point);
            }
        } else
        {
            plRt.preview.SetActive(false);
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
