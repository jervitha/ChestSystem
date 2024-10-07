using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestView : MonoBehaviour
{

    public ChestModel chestModel;
    public ChestController chestController;
    public  Button button ;
    public Image chestImage;
    public TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI timerText;
    

   void Start()
    {
        chestModel = new ChestModel();
        chestController = new ChestController(this,button,chestModel);
        chestController.Start();
    }

    public void DisplayOpenChest()
    {
       
        chestImage.sprite = chestModel.chestSO.unlockedChest;
    }

    private void Update()
    {
        chestController.Update();
    }

    public void UpdateTimer(float timeLeft)
    {
        timerText.text = "Time left: " + Mathf.Ceil(timeLeft).ToString() + "s";
    }
    
    public void ResetTimerText()
    {
        timerText.text = " ";
    }
    
}
