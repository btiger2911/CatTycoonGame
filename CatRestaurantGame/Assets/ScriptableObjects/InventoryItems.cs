using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItems", menuName = "Scriptable Objects/InventoryItems")]
public class InventoryItems : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();




    public enum StatToChange
    {
        none,
        cost,

    }
}
