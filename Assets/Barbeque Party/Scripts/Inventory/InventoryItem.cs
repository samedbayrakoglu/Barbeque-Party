using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public RewardType rewardType;
    public int amount;


    //constructor
    public InventoryItem(RewardType rewardType, int amount)
    {
        this.rewardType = rewardType;
        this.amount = amount;
    }
}
