using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;


public class PlayerInput : MonoBehaviour
{
    public enum LookDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    private GameInput gameInput;
    [SerializeField] private MovementScript p_movementScript;

    public event Action OnInteractionPerformed;
        AnimationNames animNames = new AnimationNames();
    [SerializeField] private Vector2 movementDir;
    public Vector2 aimDirection { get; private set; }
    public LookDirection currentLookDirection;

    private void Start()
    {
        gameInput = new GameInput();
        gameInput.Player.Enable();
        currentLookDirection = LookDirection.Up;
        gameInput.Player.Interact.performed += GameInput_InteractionPerformed;

    }

    private void GameInput_InteractionPerformed(InputAction.CallbackContext obj)
    {
        OnInteractionPerformed?.Invoke();
    }


    public Vector2 GetMovementVectorNormalized()
    {
        movementDir = gameInput.Player.Movement.ReadValue<Vector2>();
        if (movementDir != Vector2.zero)
        {
            aimDirection = movementDir;
        }
        if (aimDirection.x != 0)
        {
            currentLookDirection = aimDirection.x < 0 ? LookDirection.Left : LookDirection.Right;
        }
        else
        {
            currentLookDirection = aimDirection.y < 0 ? LookDirection.Down : LookDirection.Up;
        }
        return movementDir;
    }
}
