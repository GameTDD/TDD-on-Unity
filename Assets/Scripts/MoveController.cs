using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var deltaTime = Time.deltaTime;

        float x = SpeedByFrame(h, deltaTime);
        float z = SpeedByFrame(v, deltaTime);

        _rb.MovePosition(transform.position + new Vector3(x, 0, z));
    }

    public float SpeedByFrame(float axis, float deltaTime) => axis * speed * deltaTime;
}
