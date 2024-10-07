using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChestGeneration : MonobehaviourSingleton<ChestGeneration>
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
            PopupManager.instance.DisplayInfoPopup("SLOTS ARE FULL");
            return; 
        }

        
        int randomIndex = Random.Range(0, chestList.Count);
        ChestSO generatedChest = chestList[randomIndex];
        ChestDIsplayInfo availableSlot = chestDIsplayInfos[availableSlotIndex];
        ChestView chestView = availableSlot.chestView;
        chestView.chestImage.sprite = generatedChest.lockedChest;
        chestView.nameText.text = "Chest: " + generatedChest.chestName;
        chestView.chestModel.chestSO = generatedChest;
        chestView.chestController.AddButtonlisterner();
        availableSlot.isEmpty = false;
       
       
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

    public void OpenChest(ChestView chestView)
    {
        foreach(ChestDIsplayInfo chestInfo in chestDIsplayInfos)
        {
            if(chestInfo.chestView==chestView)
            {
                chestInfo.isEmpty = true;
            }
        }
        

        
    }
    public bool IsTimerRunning()
    {
        foreach (ChestDIsplayInfo chestInfo in chestDIsplayInfos)
        {
            if (chestInfo.chestView.chestController.isTimerRunning)
                return true;

        }
        return false;
    }

   
}
