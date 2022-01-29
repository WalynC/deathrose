using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseMovement : MonoBehaviour
{
    public NightControl input;
    public CharacterController controller;
    
    void FixedUpdate()
    {
        controller.Move(new Vector3(input.lateral.x, 0, input.lateral.y) * 10f * Time.deltaTime);
    }
}
