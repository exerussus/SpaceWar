
using UnityEngine;

public class PlayerKeyboardController : KeyboardController
{
    protected override bool IsPressRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    protected override bool IsPressLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    protected override bool IsPressForward()
    {
        return Input.GetKey(KeyCode.W);
    }

    protected override bool IsPressBack()
    {
        return Input.GetKey(KeyCode.S);
    }

    protected override bool IsPressAttack()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }
}
