using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockedState : IChestState
{
   
    private ChestView chestView;


    public UnLockedState(ChestView _chestView)
    {
        
        chestView = _chestView;
    }
    public void EnterState()
    {

        chestView.SetImageSprite(chestView.ChestController.GetSO().unlockedChest);
      
        OpenChest();

   }
    public void UpdateState()
    {

    }

    private void OpenChest()
    {

        ChestSO chestSO = chestView.ChestController.GetSO();
        int randomCoins = Random.Range(chestSO.minCoins, chestSO.maxCoins + 1);
        int randomGems = Random.Range(chestSO.minGems, chestSO.maxGems + 1);

        string text = $"You found {randomCoins} coins and {randomGems} gems!";
        PopupManager.Instance.DisplayInfoPopup(text);
        ResourcesDisplay.Instance.AddCoins(randomCoins);
        ResourcesDisplay.Instance.AddGems(randomGems);


    }
}
