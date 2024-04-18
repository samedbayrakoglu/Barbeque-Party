using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header(" Events ")]
    public Action OnSpin; // action called by spin button
    public Action<UIFoodContainer> OnRewardSelection; // action called by reward manager
    public Action OnRewadrCollectionComplete; // action called by inventory reward collector
    public Action<RewardType, int> OnRewardCollected; // action called by inventory reward collector


    public void SpinOrder()
    {
        OnSpin?.Invoke();
    }

    public void RewardSelected(UIFoodContainer selectedContainer)
    {
        OnRewardSelection?.Invoke(selectedContainer);
    }

    public void RewardCollectionCompleted()
    {
        OnRewadrCollectionComplete?.Invoke();
    }

    public void RewardCollected(RewardType type, int amount)
    {
        OnRewardCollected?.Invoke(type, amount);
    }
}
