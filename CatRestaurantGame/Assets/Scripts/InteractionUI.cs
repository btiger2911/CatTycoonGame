using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{

    [SerializeField] GameObject interactionPrompt;
    [SerializeField] string cookingStation;
    private bool playerNearby;

    private MiniGameUI minigameUI;

    void Start()
    {

        minigameUI = FindAnyObjectByType<MiniGameUI>();
        interactionPrompt.SetActive(false);
    }

    
    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (minigameUI != null && minigameUI.IsMiniGameActive())
            {
                minigameUI.CloseAllMinigames();
            }
            else
            {
                minigameUI.MiniGameOpen(cookingStation);
            }
          
           
        } 


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            playerNearby = true;
            interactionPrompt.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            interactionPrompt.SetActive(false);
        }
    }
}
