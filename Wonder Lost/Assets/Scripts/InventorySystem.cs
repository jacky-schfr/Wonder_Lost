using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> itemDictionary;
    public List <InventoryItem> inventory { get; private set; }


    private void Awake()
    {
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if(itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData refenenceData)
    {
        if(itemDictionary.TryGetValue(refenenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(refenenceData);
            inventory.Add(newItem);
            itemDictionary.Add(refenenceData, newItem);
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if(itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                itemDictionary.Remove(referenceData);
            }
        }
    }
}
