using UnityEngine;

public static class InputManager
{
    public static bool ActionJump()
    {
        return (Input.GetButtonDown("Jump"));
    }
}
