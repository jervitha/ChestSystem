using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChestGeneration : MonoBehaviour
{
    [SerializeField] private Button generateChestButton;
    [SerializeField] private List<ChestSO> chestList;
    [SerializeField] private ChestDIsplayInfo[] chestDIsplayInfos;


    private void OnEnable()
    {
        generateChestButton.onClick.AddListener(GenerateChest);
    }

    private void OnDisable()
    {
        
        generateChestButton.onClick.RemoveListener(GenerateChest);
    }

    private void GenerateChest()
    {
        
        int availableSlotIndex = GetAvailableSlot();

        if (availableSlotIndex == -1)
        {
            Debug.Log("All chest slots are full!");
            return; 
        }

        
        int randomIndex = Random.Range(0, chestList.Count);
        ChestSO generatedChest = chestList[randomIndex];
        ChestDIsplayInfo availableSlot = chestDIsplayInfos[availableSlotIndex];
        availableSlot.chestView.chestImage.sprite = generatedChest.lockedChest;
        availableSlot.chestView.nameText.text = "Chest: " + generatedChest.chestName;
        availableSlot.isEmpty = false;
        availableSlot.chestView.chestModel.chestSO =generatedChest;
        availableSlot.chestView.EnableButton();
        Debug.Log($"Generated {generatedChest.chestName} in slot {availableSlotIndex}");
    }

   
    private int GetAvailableSlot()
    {
        for (int i = 0; i < chestDIsplayInfos.Length; i++)
        {
            if (chestDIsplayInfos[i].isEmpty) 
            {
                return i;
            }
        }
        return -1; 
    }

   
}
