using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{


    [SerializeField] GameObject interactionPromptKeyboard;
    [SerializeField] GameObject interactionPromptGamePad;

    [SerializeField] private string itemName;

    [SerializeField] private int itemQuantity;

    [SerializeField] private Sprite sprite;

    private Inventory inventoryManager;

    private GameInput gameInput;

    private bool playerNearby;

    private string lastUsedInput = "Keyboard";
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryUI").GetComponent<Inventory>();
        gameInput = FindAnyObjectByType<GameInput>();
    }

    void Update()
    {
        if (playerNearby)
        {
            CheckInputDevice();


            if (gameInput != null && gameInput.GetInteractionButtonPressed())
            {
                int leftOverItems = inventoryManager.AddItem(itemName, itemQuantity, sprite);
                if (leftOverItems <= 0)
                {
                    interactionPromptKeyboard.SetActive(false);
                    interactionPromptGamePad.SetActive(false);
                    Destroy(gameObject);
                }
                    
                


                else
                    itemQuantity = leftOverItems;


            }
        }
    }
    private void CheckInputDevice()
    {
        bool isUsingGamepad = Gamepad.current != null && (IsAnyGamepadButtonPressed() || Gamepad.current.leftStick.ReadValue().magnitude > 0.1f);
        bool isUsingKeyboard = Keyboard.current != null && (Keyboard.current.anyKey.isPressed || Mouse.current.delta.ReadValue().magnitude > 0.1f);

        // Determine last used input
        if (isUsingGamepad) lastUsedInput = "Gamepad";
        if (isUsingKeyboard) lastUsedInput = "Keyboard";

        // Update UI
        interactionPromptGamePad.SetActive(lastUsedInput == "Gamepad");
        interactionPromptKeyboard.SetActive(lastUsedInput == "Keyboard");
    }

    private bool IsAnyGamepadButtonPressed()
    {
        if (Gamepad.current == null) return false;

        foreach (var control in Gamepad.current.allControls)
        {
            if (control is ButtonControl button && button.isPressed)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            CheckInputDevice();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            interactionPromptKeyboard.SetActive(false);
            interactionPromptGamePad.SetActive(false);
        }
    }

}
