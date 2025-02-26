using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryMenu;

    private bool menuActivated;
    

    private GameInput gameInput;
    void Start()
    {
        gameInput = FindAnyObjectByType<GameInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuActivated && gameInput.InventoryButtonPressed())
        {
            inventoryMenu.SetActive(true);
            menuActivated = true;
            Time.timeScale = 0f;
            
        }

        else if (inventoryMenu && gameInput.InventoryButtonPressed())
        {
            inventoryMenu.SetActive(false);
            menuActivated = false;
            Time.timeScale = 1f;

        }

    }
}
