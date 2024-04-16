using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header( " Events ")]
    public Action OnSpin; // action called by spin button
    public Action<UIFoodContainer> OnRewardSelection; // action called by reward manager


    public void SpinOrder()
    {
        OnSpin?.Invoke();
    }

    public void RewardSelected(UIFoodContainer selectedContainer)
    {
        OnRewardSelection?.Invoke(selectedContainer);
    }
}
