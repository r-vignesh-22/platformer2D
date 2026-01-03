using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerAction actions;

    public event Action<float> OnMoveX;
    public event Action<bool> OnJump;
    public event Action<bool> OnDash;

    void Awake()
    {
        actions = new PlayerAction();
    }

    void OnEnable()
    {
        actions.Enable();

        actions.Player.Walk.performed += ctx => OnMoveX?.Invoke(ctx.ReadValue<float>());
        actions.Player.Walk.canceled += ctx => OnMoveX?.Invoke(0);

        actions.Player.Jump.performed += ctx => OnJump?.Invoke(true);
        actions.Player.Jump.canceled += ctx => OnJump?.Invoke(false);

        actions.Player.Dash.performed += ctx => OnDash?.Invoke(true);
        actions.Player.Dash.canceled += ctx => OnDash?.Invoke(false);
    }

    void OnDisable()
    {
        actions.Disable();
    }
    
}
