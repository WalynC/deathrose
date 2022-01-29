using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseMovement : MonoBehaviour
{
    public static RoseMovement instance;

    public NightControl input;
    public CharacterController controller;
    public float hitByBulletTimer;

    public void Hit()
    {
        hitByBulletTimer = 1f;
    }

    private void Start()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        float speed = 10f;
        if (hitByBulletTimer > 0f) speed /= 2f;
        hitByBulletTimer -= Time.deltaTime;
        controller.Move(new Vector3(input.lateral.x, 0, input.lateral.z) * speed * Time.deltaTime);
    }
}
