using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header( "Data")]
    [SerializeField] private RewardData[] rewardData;



    private void Awake() 
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);    
    }

    public RewardData GetRewardData(RewardType type)
    {
        for (int i = 0; i < rewardData.Length; i++)
        {
            if(rewardData[i].type == type)
            {
                return rewardData[i];
            }
        }

        Debug.LogError("No Reward data found of that type");

        return null;
    }
}
