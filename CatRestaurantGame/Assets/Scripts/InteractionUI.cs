using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InteractionUI : MonoBehaviour
{

    [SerializeField] GameObject interactionPromptKeyboard;
    [SerializeField] GameObject interactionPromptGamePad;
    [SerializeField] string cookingStation;
    private bool playerNearby;

    

    private MiniGameUI minigameUI;

    private GameInput gameInput;

    private string lastUsedInput = "Keyboard";
    void Start()
    {
        gameInput = FindAnyObjectByType<GameInput>();
        minigameUI = FindAnyObjectByType<MiniGameUI>();
        interactionPromptKeyboard.SetActive(false);
        interactionPromptGamePad.SetActive(false);
    }

    
    void Update()
    {

        if (playerNearby)
        {
            CheckInputDevice();
        }

        if (playerNearby && gameInput.GetInteractionButtonPressed())
        {
            if (minigameUI != null && minigameUI.IsMiniGameActive())
            {
                minigameUI.CloseAllMinigames();
            }
            else
            {
                Debug.Log("Opening Minigame");
                minigameUI.MiniGameOpen(cookingStation);
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
        if (other.CompareTag ("Player"))
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
