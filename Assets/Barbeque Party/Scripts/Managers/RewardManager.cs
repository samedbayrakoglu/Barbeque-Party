using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [Header(" Elements ")]
    public Transform itemsParent;
    private EventManager eventManager;

    private List<UIFoodContainer> foodContainers = new List<UIFoodContainer>();
    private List<int> selectedContainerIdxs = new List<int>();

    [Header(" Actions ")]
    public Action OnReadyForSpin;



    private void Start()
    {
        SetupContainers();

        eventManager = FindObjectOfType<EventManager>();
        eventManager.OnSpin += SpinOrder;
    }

    private void SetupContainers()
    {
        for (int i = 0; i < itemsParent.childCount; i++)
        {
            UIFoodContainer container = itemsParent.GetChild(i).GetComponent<UIFoodContainer>();

            container.Reset();
            
            RewardData rewardData = DataManager.instance.GetRewardData((RewardType)i); // Random reward type selected with respect to item index
            container.Configure(rewardData);

            container.OnSelectionComplete += SelectionCompleteCallback;

            foodContainers.Add(container);
        }
    }

    private void SelectionCompleteCallback(UIFoodContainer container)
    {
        Debug.Log("time for UI");
        
        if(eventManager != null)
            eventManager.RewardSelected(container);
    }

    public void SpinOrder()
    {
        StartCoroutine(Spin());
    }

    private IEnumerator Spin()
    {
        int roundCountBeforeSelection = 2;

        // to complete 2 round before selection
        while (roundCountBeforeSelection > 0)
        {
            for (int i = 0; i < foodContainers.Count; i++)
            {
                foodContainers[i].Glow();

                yield return new WaitForSeconds(0.2f);              
            }

            roundCountBeforeSelection--; 
        }

        // after 2 rounds select a random container
        int selectedContainerIdx = GetRandomAvailableContainerIdx();

        // go to selected container
        for (int i = 0; i < foodContainers.Count; i++)
        {
            if(i == selectedContainerIdx)
            {
                foodContainers[i].Selected();

                break;
            }

            foodContainers[i].Glow();

            yield return new WaitForSeconds(0.2f);              
        }
    }

    private int GetRandomAvailableContainerIdx()
    {
        int randomIndex = UnityEngine.Random.Range(0, foodContainers.Count);

        while(selectedContainerIdxs.Contains(randomIndex))
        {
            randomIndex = UnityEngine.Random.Range(0, foodContainers.Count);
        }

        return randomIndex;
    }

    private void OnDestroy() 
    {
        // unsubscribe all containers
        for (int i = 0; i < foodContainers.Count; i++)
        {
            foodContainers[i].OnSelectionComplete -= SelectionCompleteCallback;
        }

        eventManager.OnSpin -= SpinOrder;
    }
}
