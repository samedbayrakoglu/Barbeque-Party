using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [Header( "Elements ")]
    [SerializeField] private Transform rewardContainersParent;
    [SerializeField] private InventoryItemContainer inventoryItemContainerPrefab;


    public void Configure(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetInventoryItems();

        for (int i = 0; i < items.Length; i++)
        {
            InventoryItemContainer inventoryItemContainerInstance = Instantiate(inventoryItemContainerPrefab, rewardContainersParent);

            Sprite foodIcon = DataManager.instance.GetRewardData(items[i].rewardType).foodIcon;

            inventoryItemContainerInstance.Configure(foodIcon, items[i].amount);
        }
    }

    public void UpdateDisplay(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetInventoryItems();

        for (int i = 0; i < items.Length; i++)
        {
            InventoryItemContainer containerInstance;

            if(i < rewardContainersParent.childCount)
            {
                containerInstance = rewardContainersParent.GetChild(i).GetComponent<InventoryItemContainer>();
                containerInstance.gameObject.SetActive(true);
            }
            else
            {
                containerInstance = Instantiate(inventoryItemContainerPrefab, rewardContainersParent);
            }

            Sprite foodIcon = DataManager.instance.GetRewardData(items[i].rewardType).foodIcon;

            containerInstance.Configure(foodIcon, items[i].amount);
        }


        // if there are extra containers
        int remainingContaniers = rewardContainersParent.childCount - items.Length;

        if(remainingContaniers <= 0)
            return;
        
        for (int i = 0; i < remainingContaniers; i++)
        {
            rewardContainersParent.GetChild(items.Length + i).gameObject.SetActive(false);
        }
    }
}

