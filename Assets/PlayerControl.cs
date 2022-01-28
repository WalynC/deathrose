using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Camera cam;
    public LayerMask hittable;
    public PlantRoot plRt;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, hittable))
            {
                plRt.CreateObject(Vector3.zero, hit.point);
            }
        }
    }
}
