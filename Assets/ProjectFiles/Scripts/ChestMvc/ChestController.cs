using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Threading.Tasks;
public class ChestController 
{
    private  ChestView chestView;
    public ChestModel chestModel;
    private IChestState currentState;
    private LockedState lockedState;
    private UnLockedState unLockedState;
    private WaitingState waitingState;
    private Button button;
    public bool isTimerRunning;

    public void Start()
    {
        AddButtonlisterner();
        currentState = lockedState;
        currentState.EnterState();
        waitingState = new WaitingState(this, chestView);
    }

    public ChestController(ChestView _chestView,Button _button,ChestModel _chestModel)
    {
        button = _button;
        chestView = _chestView;

        chestModel = _chestModel;
        lockedState = new LockedState();
        unLockedState = new UnLockedState(chestView);
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

    public async void UnlockChest()
    {

        button.onClick.RemoveAllListeners();
        chestView.DisplayOpenChest();

        
        SetState(unLockedState);
        await Task.Delay(2000);
        button.image.sprite = null;
        SetState(lockedState);
        ChestGeneration.Instance.OpenChest(chestView);
        chestView.ResetTimerText();

    }

    public void WaitForConfirmation()
    {
        SetState(waitingState);
        isTimerRunning = true;


    }

 
   public void TimerFinish()
    {
        button.onClick.AddListener(UnlockChest);
        isTimerRunning = false;
     }

    public void AddButtonlisterner()
    {
        button.onClick.AddListener(() =>
        {
            PopupManager.Instance.DisplayConfirmationPopup(this);
            button.onClick.RemoveAllListeners();

        });

    }

    public ChestSO GetSO()
    {
        return chestModel.chestSO;
    }

}
