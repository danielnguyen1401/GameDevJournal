using System;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private BaseCameraState state;
    public Transform CameraContainer { get; set; }
    public Vector3 InputVector { get; set; }

    public void Init()
    {
        CameraContainer = new GameObject("Camera Container").transform;
        CameraContainer.gameObject.AddComponent<Camera>();
        CameraContainer.tag = "MainCamera";
        state = gameObject.AddComponent<FirstPersonCamera>() as BaseCameraState;
        state.Construct();
    }

    void Start()
    {
    }

    void Update()
    {
        InputVector = GetInput();
    }

    Vector3 GetInput()
    {
        Vector3 dir= Vector3.zero;
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if (dir.magnitude > 1)
            dir.Normalize();
        return dir;
    }
    void LateUpdate()
    {
        CameraContainer.position = state.ProcessMotion(InputVector);
        CameraContainer.rotation = state.ProcessRotation(InputVector);

    }

    public void ChangeState(string stateName)
    {
        Type t = Type.GetType(stateName);
        state.Destruct();
        state = gameObject.AddComponent(t) as BaseCameraState;
        state.Construct();
    }
}
