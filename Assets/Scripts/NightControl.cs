using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightControl : MonoBehaviour
{
    public Vector3 lateral = Vector3.zero;
    public BulletPool pool;
    public LayerMask targetables;

    void Update()
    {
        RoseMovement.instance.transform.eulerAngles = CameraController.instance.transform.eulerAngles;
        lateral = 
            RoseMovement.instance.transform.right * Input.GetAxis("Horizontal")+
            RoseMovement.instance.transform.forward * Input.GetAxis("Vertical"); 
        CameraController.instance.transform.position = RoseMovement.instance.transform.position;
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit hit;
            if (Physics.Raycast(CameraController.cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, targetables))
            {
                GameObject obj = pool.GetObject();
                Bullet bull = obj.GetComponent<Bullet>();
                obj.transform.position = RoseMovement.instance.transform.position;
                bull.Setup(null, hit.point, pool);
            }
        }
    }
}
