using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        float x = h * speed * Time.deltaTime;
        float z = v * speed * Time.deltaTime;

        _rb.MovePosition(transform.position + new Vector3(x, 0, z));
    }
}
