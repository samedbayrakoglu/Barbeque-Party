using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


}
