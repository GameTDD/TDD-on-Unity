using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothing = 10f;
    public Transform target;

    public Vector3 Offset { get; set; }

    void Start()
    {
        Offset = transform.position - target.position;

    }

    void FixedUpdate()
    {
        Vector3 targetCam = target.position + Offset;
        transform.position = Vector3.Lerp(transform.position, targetCam, smoothing * Time.deltaTime);
    }
}
