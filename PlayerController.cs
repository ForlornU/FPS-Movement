using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Movement
{
    public PlayerControls _playerControls;

    private void OnEnable()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();

        _playerControls.Player.Jump.performed += InputJump;
        _playerControls.Player.Dash.performed += InputDash;
        _playerControls.Player.Crouch.performed += InputCrouch;
    }

    Vector2 InputMovement()
    {
        return _playerControls.Player.Move.ReadValue<Vector2>();
    }

    private void InputJump(InputAction.CallbackContext context)
    {
        Jump();
    }

    private void InputDash(InputAction.CallbackContext context)
    {
        StartCoroutine(Dash());
    }

    private void InputCrouch(InputAction.CallbackContext context)
    {
        Crouch();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        UpdateMovement(InputMovement());
    }
    
}
