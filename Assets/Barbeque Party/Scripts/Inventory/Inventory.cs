using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    [SerializeField] private List<InventoryItem> inventoryItems = new List<InventoryItem>();


    public void RewardCollectedCallback(RewardType rewardType, int amount)
    {
        bool rewardFound = false;

        for (int i = 0; i < inventoryItems.Count; i++)
        {
           InventoryItem item = inventoryItems[i];

           if(item.rewardType == rewardType)
           {
                item.amount += amount;

                rewardFound = true;

                break;
           } 
        }

        if(rewardFound)
            return;

        // create new reward item
        inventoryItems.Add(new InventoryItem(rewardType, amount));
    }

    public InventoryItem[] GetInventoryItems()
    {
        return inventoryItems.ToArray();
    }

    public void Clear()
    {
        inventoryItems.Clear();
    }
}
