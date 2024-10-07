using UnityEngine;
using System.Collections;

public class WaitingState : IChestState
{
    private ChestView chestView;
    private ChestController chestController;
    private float waitTime;
    private float timer;
    private bool isTimerCompleted;
    

    public WaitingState(ChestController _chestController, ChestView _chestView)
    {
        chestController = _chestController;
        chestView = _chestView;
    }

    public void EnterState()
    {
        timer = 0;
        waitTime = chestView.chestModel.chestSO.timerDuration;

    }
    public void UpdateState()
    {
        if (isTimerCompleted)
        {
            return;
        }
        timer += Time.deltaTime;
        float timeLeft = waitTime - timer;
        chestView.UpdateTimer(timeLeft);
        if (timer >= waitTime)
        {
            timer = 0;
            isTimerCompleted = true;
            chestController.TimerFinish();
        }

    }
}


