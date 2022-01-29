using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseMovement : MonoBehaviour
{
    public static RoseMovement instance;

    public NightControl input;
    public CharacterController controller;

    private void Start()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        controller.Move(new Vector3(input.lateral.x, 0, input.lateral.y) * 10f * Time.deltaTime);
    }
}
