using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public Transform itemsParent;

    private List<UIFoodContainer> foodContainers = new List<UIFoodContainer>();



    private void Start()
    {
        for (int i = 0; i < itemsParent.childCount; i++)
        {
            UIFoodContainer container = itemsParent.GetChild(i).GetComponent<UIFoodContainer>();

            container.Reset();
            
            RewardData rewardData = DataManager.instance.GetRewardData((RewardType)i); // Random reward type selected with respect to item index
            container.Configure(rewardData);

            foodContainers.Add(container);
        }
    }
}
