﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
    }
}
