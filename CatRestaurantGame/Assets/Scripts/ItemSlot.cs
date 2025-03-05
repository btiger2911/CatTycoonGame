using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    public string itemName;
    public int itemQuantity;
    public Sprite itemSprite;
    public bool isFull;
   

    [SerializeField] private int maxNumberOfItems;

    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
   public int AddItem(string itemName, int itemQuantity, Sprite itemSprite)
    {
        if (isFull)
        {
            return itemQuantity;
        }

        this.itemName = itemName;
        
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        this.itemQuantity += itemQuantity;
        if (this.itemQuantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            int extraItems = this.itemQuantity - maxNumberOfItems;
            this.itemQuantity = maxNumberOfItems;
            return extraItems;
        }

        quantityText.text = this.itemQuantity.ToString();
        quantityText.enabled = true;

        return 0;




    }


   
}
