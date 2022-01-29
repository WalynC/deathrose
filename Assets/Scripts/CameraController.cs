using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static CameraController _inst;
    public static CameraController instance {
        get
        {
            if (_inst == null) _inst = FindObjectOfType<CameraController>();
            return _inst;
        }
    }
    public static Camera cam;
    float rot = 0f;

    void Start()
    {
        cam = Camera.main;
        _inst = this;   
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E)) rot++;
        if (Input.GetKey(KeyCode.Q)) rot--;
        transform.eulerAngles = new Vector3(0, rot, 0);
    }
}
