using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody _rb;
    public IUnityService service;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (service == null)
        {
            service = this.gameObject.AddComponent<UnityMoveService>();
        }
    }

    void Update()
    {
        float x = SpeedByFrame(service.GetInputAxis("Horizontal"), service.GetDeltaTime());
        float z = SpeedByFrame(service.GetInputAxis("Vertical"), service.GetDeltaTime());

        _rb.MovePosition(CalculatePosition(transform.position, x, z));
    }

    public float SpeedByFrame(float axis, float deltaTime) => axis * speed * deltaTime;

    public Vector3 CalculatePosition(Vector3 position, float x, float z) => position + new Vector3(x, 0, z);
}
