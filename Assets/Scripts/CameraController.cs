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
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        _inst = this;   
    }
}
