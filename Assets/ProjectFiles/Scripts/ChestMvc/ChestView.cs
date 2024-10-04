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
    [SerializeField] public Image chestImage;
    [SerializeField] public TextMeshProUGUI chestStateText;
  
    [SerializeField] private TextMeshProUGUI timerText;
    public TextMeshProUGUI nameText;

   


    void Start()
    {
        chestModel = new ChestModel();
        chestController = new ChestController(this,button);
        chestController.Start();
    }

    public void DisplayOpenChest()
    {
       
        chestImage.sprite = chestModel.chestSO.unlockedChest;
        chestStateText.text = "Chest Unlocked!";
        
    }

    private void Update()
    {
        chestController.Update();
    }

    public void UpdateTimer(float timeLeft)
    {
        timerText.text = "Time left: " + Mathf.Ceil(timeLeft).ToString() + "s";
    }
    public void DisableButton()
    {
        button.enabled = false;
    }
    public void EnableButton()
    {
        button.enabled = true;
    }
}
