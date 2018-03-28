using UnityEngine;

public class WalkingState : BaseState
{
    public override Vector3 ProcessMotion(Vector3 input)
    {
        return input * motor.Speed;
    }

    public override Quaternion ProcessRotation(Vector3 input)
    {
        return Quaternion.FromToRotation(transform.forward, input);
    }
}
