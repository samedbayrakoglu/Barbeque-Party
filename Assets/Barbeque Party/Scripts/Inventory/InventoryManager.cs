using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[RequireComponent(typeof(InventoryDisplay))]
public class InventoryManager : MonoBehaviour
{
    private Inventory inventory;
    private InventoryDisplay inventoryDisplay;

    private string dataPath;

    private EventManager eventManager;


    private void Start() 
    {
        dataPath = Application.dataPath + "/InventoryData.txt";

        LoadInventory();
        ConfigureInventoryDisplay();

        eventManager = FindObjectOfType<EventManager>();
        eventManager.OnRewardCollected += RewardCollectedCallback;
    }

    private void RewardCollectedCallback(RewardType type, int amount)
    {
        inventory.RewardCollectedCallback(type, amount);

        inventoryDisplay.UpdateDisplay(inventory);

        SaveInventory();
    }

    private void ClearInventory()
    {
        inventory.Clear();
        inventoryDisplay.UpdateDisplay(inventory);

        SaveInventory();
    }

    private void ConfigureInventoryDisplay()
    {
        inventoryDisplay = GetComponent<InventoryDisplay>();
        inventoryDisplay.Configure(inventory);
    }

    private void LoadInventory()
    {
        string data = "";

        if(File.Exists(dataPath))
        {
            data = File.ReadAllText(dataPath);

            inventory = JsonUtility.FromJson<Inventory>(data);

            if(inventory == null)
                inventory = new Inventory();           
        }
        else
        {
            File.Create(dataPath).Dispose();

            inventory = new Inventory();
        }
    }

    private void SaveInventory()
    {
        string data = JsonUtility.ToJson(inventory, true);

        File.WriteAllText(dataPath, data);
    }

    private void OnDestroy() 
    {
        eventManager.OnRewardCollected -= RewardCollectedCallback;
    }
}


