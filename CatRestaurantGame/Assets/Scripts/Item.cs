using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;

    [SerializeField] private int itemQuantity;

    [SerializeField] private Sprite sprite;

    private Inventory inventoryManager;
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryUI").GetComponent<Inventory>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           int leftOverItems = inventoryManager.AddItem(itemName, itemQuantity, sprite);
            if (leftOverItems <= 0)
                Destroy(gameObject);
            else
                itemQuantity = leftOverItems;


        }
    }
}
