using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float SpeedByFrame(float axis, float speed, float deltaTime) => axis * speed * deltaTime;

    public Vector3 CalculatePosition(Vector3 position, float x, float z) => position + new Vector3(x, 0, z);
}
