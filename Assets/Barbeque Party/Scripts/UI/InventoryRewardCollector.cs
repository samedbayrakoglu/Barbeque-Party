using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InventoryRewardCollector : MonoBehaviour
{
    private EventManager eventManager;

    private List<GameObject> iconList = new List<GameObject>();

    [Header(" Settings ")]
    public float splitDuration = 1f;
    public float maxDelayToMoveToBag = 1.8f;
    public float moveDuration = 1f;
    public int rewardAmount = 6;


    private void Start() 
    {
        eventManager = FindObjectOfType<EventManager>();
        eventManager.OnRewardSelection += Collect;
    }

    private void Collect(UIFoodContainer container)
    {
        // add foods to inventory
        if(eventManager != null)
            eventManager.OnRewardCollected(container.rewardData.type, rewardAmount);

        SplitRewardIcons(container.rewardData.foodPrefab);

        // after all icons reached to bag
        DOVirtual.DelayedCall(maxDelayToMoveToBag + moveDuration + splitDuration, () => 
        {
            if(eventManager != null)
                eventManager.RewardCollectionCompleted();

            // destroy all food icons
            for (int i = 0; i < iconList.Count; i++)
            {
                Destroy(iconList[0]);
            }
        });
    }

    private void SplitRewardIcons(GameObject foodPrefab)
    {
        for (int i = 0; i < rewardAmount; i++)
        {
            GameObject foodIcon = Instantiate(foodPrefab, new Vector2(Screen.width * 0.5f, Screen.height * 0.5f) , Quaternion.identity, transform);
            foodIcon.transform.localScale = Vector3.zero;

            iconList.Add(foodIcon);

            // scale up just created icon
            foodIcon.transform.DOScale(Vector3.one, 0.5f); 

            // start Endless rotate
            // foodIcon.transform.DOLocalRotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
            
            Move(foodIcon);
        }
    }

    private void Move(GameObject foodIcon)
    {
        // random delay for each 
        float delay = Random.Range(0f, maxDelayToMoveToBag);

        // move to random position on screen
        foodIcon.transform.DOMove(GetRandomPosition(), splitDuration).OnComplete(() => 
        {
            // move to bag
            foodIcon.transform.DOMove(transform.position , moveDuration).SetDelay(delay);

            // scale down while moving
            foodIcon.transform.DOScale(Vector3.zero, 0.65f).SetDelay(delay).SetEase(Ease.InQuart);
        });
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 randPos = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f) + Random.insideUnitCircle * Screen.width * 0.2f;

        return randPos;
    }
}
