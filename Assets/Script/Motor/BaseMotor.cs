using System;
using UnityEngine;

public abstract class BaseMotor : MonoBehaviour
{
    protected CharacterController charController;
    protected BaseState state;
    protected Transform thisTransform;

    [SerializeField] float _speed = 20f;
    [SerializeField] float _gravity = 25.0f;
    [SerializeField] float _terminalVelocity = 30f;
    [SerializeField] float _jumpForce = 30f;

    public Vector3 MoveVector { get; set; }
    public float VerticalVelocity { get; set; }
    public Quaternion RotationQuaternion { get; set; }
    public float Speed { get { return _speed; } }
    public float Gravity { get { return _gravity; } }
    public float JumpForce{ get { return _jumpForce; } }
    public float TerminalVelocity{ get { return _terminalVelocity; } }
    protected abstract void UpdateMotor();

    protected virtual void Start()
    {
        charController = gameObject.GetComponent<CharacterController>();
        thisTransform = transform;
    }

    void Update()
    {
        UpdateMotor();
    }

    protected virtual void Move()
    {
        charController.Move(MoveVector * Time.deltaTime);
    }

    protected virtual void Rotate()
    {
        thisTransform.rotation = RotationQuaternion;
    }


    public void ChangeState(string stateName)
    {
        Type t = Type.GetType(stateName);

        state.Destruct();
        state = gameObject.AddComponent(t) as BaseState;
        state.Construct();
    }

    public virtual bool Ground()
    {
        RaycastHit hit;
        Vector3 ray;

        float yRay = (charController.bounds.center.y - charController.bounds.extents.y) + .3f, // + security margin in case object slightly below floor
            centerX = charController.bounds.center.x - 0.1f,
            centerZ = charController.bounds.center.z - 0.1f,
            extentX = charController.bounds.extents.x - 0.1f,
            extentZ = charController.bounds.extents.z - 0.1f;

        ray = new Vector3(centerX, yRay, centerZ);
        if (Physics.Raycast(ray, Vector3.down, out hit, 0.5f))
            return true;
        ray = new Vector3(centerX + extentX, yRay, centerZ + extentZ);
        if (Physics.Raycast(ray, Vector3.down, out hit, 0.5f))
            return true;
        ray = new Vector3(centerX - extentX, yRay, centerZ + extentZ);
        if (Physics.Raycast(ray, Vector3.down, out hit, 0.5f))
            return true;
        ray = new Vector3(centerX + extentX, yRay, centerZ - extentZ);
        if (Physics.Raycast(ray, Vector3.down, out hit, 0.5f))
            return true;
        ray = new Vector3(centerX - extentX, yRay, centerZ - extentZ);
        if (Physics.Raycast(ray, Vector3.down, out hit, 0.5f))
            return true;

        return false;
    }
}
