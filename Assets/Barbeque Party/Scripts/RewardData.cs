using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Reward Data", menuName = "Scriptable Objects/Reward Data", order = 0)]
public class RewardData : ScriptableObject
{
    [Header(" Elements")]
    public RewardType type;
    public Sprite foodIcon;
    public GameObject foodPrefab;
}
