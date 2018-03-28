using UnityEngine;

public class PlayerMotor : BaseMotor
{
    protected override void UpdateMotor()
    {
        MoveVector = InputDirection();
        MoveVector = state.ProcessMotion(MoveVector);
        RotationQuaternion = state.ProcessRotation(MoveVector);
        Move();
    }

    Vector3 InputDirection()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }
        return dir;
    }
}
