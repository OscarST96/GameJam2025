using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public static event Action<Vector2> OnMove;
    public static event Action OnJump;
    public static event Action OnChangeColor;
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f) return;

        if (context.performed || context.canceled)
        {
            OnMove?.Invoke(context.ReadValue<Vector2>());
        }
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f) return;

        if (context.performed)
        {
            OnJump?.Invoke();
        }
    }
    public void OnChangeColorInput(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f) return;

        if (context.performed)
        {
            OnChangeColor?.Invoke();
        }
    }
}
