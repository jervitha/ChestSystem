using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class ChestController 
{
    public  ChestView chestView;
    private IChestState currentState;
    private LockedState lockedState;
    private UnLockedState unLockedState;
    private WaitingState waitingState;
    
    private Button button;
    public void Start()
    {
        AddButtonlisterner();



        button.enabled = false;
        currentState = lockedState;
         currentState.EnterState();
        waitingState = new WaitingState(this,chestView);
     }

    public ChestController(ChestView _chestView,Button _button)
    {
        button = _button;
        chestView = _chestView;
       

        lockedState = new LockedState();
        unLockedState = new UnLockedState(this);
        waitingState = new WaitingState(this, chestView);

    }

    
    public void Update()
    {
        currentState.UpdateState();
    }
    public void SetState(IChestState newState)
    {
        currentState = newState;
        currentState.EnterState();
    }

    public void UnlockChest()
    {
        
        ChestSO chestSO = chestView.chestModel.chestSO;
        chestView.DisplayOpenChest();
        SetState(unLockedState);
        int randomCoins = Random.Range(chestSO.minCoins, chestSO.maxCoins + 1);
        int randomGems = Random.Range(chestSO.minGems, chestSO.maxGems + 1);

        string text= $"You found {randomCoins} coins and {randomGems} gems!";
        PopupManager.instance.DisplayInfoPopup(text);
    }

    public void WaitForConfirmation()
    {
        SetState(waitingState);
    }

 
   public void TimerFinish()
    {
        button.enabled = true;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(UnlockChest);

    }

    public void AddButtonlisterner()
    {
        button.onClick.AddListener(() =>
        {
            PopupManager.instance.DisplayConfirmationPopup(this);
            button.onClick.RemoveAllListeners();

        });

    }

}
