using UnityEngine;

public abstract class BaseMotor : MonoBehaviour
{
    protected CharacterController charController;
    protected BaseState state;
    protected Transform thisTransform;

    [SerializeField] float _speed = 20f;
    [SerializeField] float _gravity = 25.0f;

    public Vector3 MoveVector { get; set; }

    public float Speed
    {
        get { return _speed; }
    }

    public float Gravity
    {
        get { return _gravity; }
    }

    protected abstract void UpdateMotor();

    void Start()
    {
        charController = gameObject.GetComponent<CharacterController>();
        thisTransform = transform;
        state = gameObject.GetComponent<WalkingState>();
        state.Construct();
    }

    void Update()
    {
        UpdateMotor();
    }

    protected virtual void Move()
    {
        charController.Move(MoveVector * Time.deltaTime);
    }
}
