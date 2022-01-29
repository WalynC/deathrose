using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightControl : MonoBehaviour
{
    public Vector2 lateral = Vector2.zero;
    public BulletPool pool;
    public LayerMask targetables;

    void Update()
    {
        lateral = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space)) GameState.instance.DaytimeBegin();
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
