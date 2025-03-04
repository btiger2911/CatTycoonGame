using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryMenu;

    private bool menuActivated;


    public ItemSlot[] itemSlot;
    

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

        else if (menuActivated && gameInput.InventoryButtonPressed())
        {
            inventoryMenu.SetActive(false);
            menuActivated = false;
            Time.timeScale = 1f;

        }

    }

    public int AddItem(string itemName, int itemQuantity, Sprite itemSprite)
    {
       


        for (int i = 0; i <itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].itemQuantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, itemQuantity, itemSprite);

                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite);

                    
                }
                return leftOverItems;

            }
        }

        return itemQuantity;
    }
}
