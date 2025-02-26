using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public bool InventoryButtonPressed()
    {
        return playerInputActions.Player.Inventory.triggered;
    }


    public bool GetInteractionButtonPressed()
    {
        return playerInputActions.Player.Interact.triggered;
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();





        inputVector = inputVector.normalized;
        return inputVector;
    }


    public bool IsDragging()
    {
        return Mouse.current.leftButton.isPressed || Gamepad.current?.rightStick.ReadValue().magnitude > 0.1f;
    }

    // Get the vertical drag input, but only if dragging is active
    public float GetDragInput()
    {
        if (!IsDragging()) return 0f; // Ignore if not dragging

        float mouseDrag = Mouse.current.delta.y.ReadValue() * 0.05f; // Adjust for better feel
        float gamepadDrag = Gamepad.current?.rightStick.y.ReadValue() * 2.5f ?? 0f; // Boost gamepad sensitivity

        return Mathf.Abs(mouseDrag) > Mathf.Abs(gamepadDrag) ? mouseDrag : gamepadDrag;
    }
}
