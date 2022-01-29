using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public static Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        instance = this;   
    }
}
