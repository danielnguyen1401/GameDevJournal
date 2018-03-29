using UnityEngine;

public class WalkingState : BaseState
{
    public override void Construct()
    {
        base.Construct();
        motor.VerticalVelocity = 0;
    }

    public override Vector3 ProcessMotion(Vector3 input)
    {
        ApplySpeed(ref input, motor.Speed);
        return input;
    }

    public override Quaternion ProcessRotation(Vector3 input)
    {
        return Quaternion.FromToRotation(transform.forward, input);
    }

    public override void Transition()
    {
        if (!motor.Ground())
        {
            motor.ChangeState("FallingState");
        }
        if (InputManager.ActionJump())
        {
            if (motor.Ground())
                motor.ChangeState("JumpingState");
        }
    }
}
