using System;
using UnityEngine;

public class ThirdPersonCamera : BaseCameraState
{
    public override Vector3 ProcessMotion(Vector3 input)
    {
        return transform.position;
    }

    public override Quaternion ProcessRotation(Vector3 input)
    {
        return transform.rotation;
    }
}
