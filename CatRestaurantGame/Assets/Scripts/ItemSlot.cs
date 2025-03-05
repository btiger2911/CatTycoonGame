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

    private void EmptySlot()
    {
        quantityText.enabled = false;
        

    }


    public void OnRightClick()
    {
        GameObject itemToDrop = new GameObject(itemName);

        Item newItem = itemToDrop.AddComponent<Item>();

        newItem.itemQuantity = 1;
        newItem.itemName = itemName;
        newItem.sprite = itemSprite;

        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 5;
        sr.sortingLayerName = "Ground";

        itemToDrop.AddComponent<BoxCollider>();


        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(.5f,0,0);
        itemToDrop.transform.localScale = new Vector3(.5f, .5f, .5f);

        this.itemQuantity -= 1;
        quantityText.text = this.itemQuantity.ToString();
        if(this.itemQuantity <= 0)
        {
            EmptySlot();
        }
    }


   
}
