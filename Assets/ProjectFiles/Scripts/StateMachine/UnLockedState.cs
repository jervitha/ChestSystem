using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockedState : IChestState
{
    private ChestController chestController;
    private ChestView chestView;


    public UnLockedState(ChestController _chestController)
    {
        chestController = _chestController;
        chestView = chestController.chestView;
    }
    public void EnterState()
    {

        chestView.chestImage.sprite = chestView.chestModel.chestSO.unlockedChest;
      
        OpenChest();

   }
    public void UpdateState()
    {

    }

    private void OpenChest()
    {

        ChestSO chestSO = chestView.chestModel.chestSO;
        int randomCoins = Random.Range(chestSO.minCoins, chestSO.maxCoins + 1);
        int randomGems = Random.Range(chestSO.minGems, chestSO.maxGems + 1);

        string text = $"You found {randomCoins} coins and {randomGems} gems!";
        PopupManager.instance.DisplayInfoPopup(text);
        ResourcesDisplay.instance.AddCoins(randomCoins);
        ResourcesDisplay.instance.AddGems(randomGems);


    }
}
