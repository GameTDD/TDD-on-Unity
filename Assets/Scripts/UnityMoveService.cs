using UnityEngine;
using System.Collections;

public class UnityMoveService : MonoBehaviour, IUnityService
{
    public float GetDeltaTime() => Time.deltaTime;

    public float GetInputAxis(string axis) => Input.GetAxis(axis);
}
