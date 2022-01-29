using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightControl : MonoBehaviour
{
    public Vector2 lateral = Vector2.zero;

    void Update()
    {
        lateral = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
