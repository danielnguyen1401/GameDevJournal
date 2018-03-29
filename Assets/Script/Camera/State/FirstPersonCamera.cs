using UnityEngine;

public class FirstPersonCamera : BaseCameraState
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
