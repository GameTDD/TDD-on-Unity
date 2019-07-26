using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 20f;
    Movement movement;
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        movement = new Movement();
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var deltaTime = Time.deltaTime;

        float x = movement.SpeedByFrame(h, speed, deltaTime);
        float z = movement.SpeedByFrame(v, speed, deltaTime);

        _rb.MovePosition(movement.CalculatePosition(transform.position, x, z));
    }
}
