using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIFoodContainer : MonoBehaviour
{
    [Header(" Elements ")]
    public Image unselectedBG;
    public Image glowBG;
    public Image selectedBG;
    public Image disabledBG;

    public Image foodIcon;
    public Image tickIcon;

    [Header(" Settings ")]
    public FoodContainerState state;
    public RewardType rewardType;

    [Header(" Actions ")]
    public Action<UIFoodContainer> OnSelectionComplete;


    public void Configure(RewardData rewardData)
    {
        rewardType = rewardData.type;

        foodIcon.sprite = rewardData.foodIcon;
    }

    public void Reset()
    {
        state = FoodContainerState.unselected;

        unselectedBG.gameObject.SetActive(true);
        foodIcon.gameObject.SetActive(true);

        glowBG.gameObject.SetActive(false);
        selectedBG.gameObject.SetActive(false);
        disabledBG.gameObject.SetActive(false);
        tickIcon.gameObject.SetActive(false);
    }

    public void Glow()
    {
        glowBG.gameObject.SetActive(true);

        glowBG.DOFade(0f, 1f).SetDelay(0.3f).OnComplete(() => 
        {
            glowBG.gameObject.SetActive(false);

            glowBG.DOFade(1f, 0f);
        });
    }

    public void Selected()
    {
        glowBG.gameObject.SetActive(true);

        glowBG.DOFade(0f, 0.2f).SetLoops(7, LoopType.Yoyo).OnComplete(() => 
        {
            glowBG.gameObject.SetActive(false);
            unselectedBG.gameObject.SetActive(false);

            selectedBG.gameObject.SetActive(true);
            tickIcon.gameObject.SetActive(true);

            OnSelectionComplete?.Invoke(this);
        });
    }

    public void Disable()
    {

    }

}
