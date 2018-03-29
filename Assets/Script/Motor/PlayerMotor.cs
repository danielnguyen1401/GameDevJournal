using UnityEngine;

public class PlayerMotor : BaseMotor
{
    private CameraMotor camMotor;

    protected override void Start()
    {
        base.Start();
        state = gameObject.AddComponent<WalkingState>();
        state.Construct();

        // Init camera from player
        camMotor = gameObject.AddComponent<CameraMotor>();
        camMotor.Init();
    }

    protected override void UpdateMotor()
    {
        MoveVector = InputDirection();
        MoveVector = state.ProcessMotion(MoveVector);
        Move();
        state.Transition();
        Ground();
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
