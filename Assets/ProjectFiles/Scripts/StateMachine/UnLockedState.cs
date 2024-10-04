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
        chestView.chestStateText.text = "Unlocked";
        chestView.EnableButton();
        chestView.button.onClick.RemoveAllListeners();
        chestView.button.onClick.AddListener(OpenChest);


    }
    public void UpdateState()
    {

    }

    private void OpenChest()
    {

        int chestCoins = Random.Range(chestView.chestModel.chestSO.minCoins, chestView.chestModel.chestSO.maxCoins + 1);
        int chestGems = Random.Range(chestView.chestModel.chestSO.minGems, chestView.chestModel.chestSO.maxGems + 1);

        // Add rewards to the player's resources via the singleton ResourcesDisplay
        ResourcesDisplay.Instance.AddCoins(chestCoins);
        ResourcesDisplay.Instance.AddGems(chestGems);

        // Disable the button after chest is opened
        chestView.DisableButton();
        chestView.chestStateText.text = "Collected";

        Debug.Log($"Chest opened! Received {chestCoins} coins and {chestGems} gems.");
        chestView.button.onClick.RemoveAllListeners();
    }
}
