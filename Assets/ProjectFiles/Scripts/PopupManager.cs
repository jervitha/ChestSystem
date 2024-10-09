using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class PopupManager : MonobehaviourSingleton<PopupManager>
{
    [SerializeField] private GameObject confirmationPopup;
    [SerializeField] private TextMeshProUGUI confirmationpopupText;
    [SerializeField] private Button confirmationyesButton;
    [SerializeField] private Button confirmationNoButton;
    [SerializeField] private Button confirmationBackButton;
    private ChestController lastChestController;




    [SerializeField] private GameObject infoPopup; // popup for information purposes
    [SerializeField] private TextMeshProUGUI infoPopupText;
    [SerializeField] private Button infoOkButton;

    private void Start()
    {
        confirmationPopup.SetActive(false);
        infoPopup.SetActive(false);
    }

    private void OnEnable()
    {
        confirmationBackButton.onClick.AddListener(OnbackbuttonClick);
        infoOkButton.onClick.AddListener(CloseInfoPopup);
        confirmationyesButton.onClick.AddListener(CloseConfirmationPopup);
        confirmationNoButton.onClick.AddListener(CloseConfirmationPopup);


    }
    private void OnDisable()
    {
        confirmationyesButton.onClick.RemoveAllListeners();
        confirmationNoButton.onClick.RemoveAllListeners();
        confirmationBackButton.onClick.RemoveAllListeners();
        infoOkButton.onClick.RemoveAllListeners();
        
    }

    public void DisplayConfirmationPopup(ChestController chestController)
    {
       
        lastChestController = chestController;
        int GemsToUnlock = lastChestController.GetSO().gemsToOpen;
        confirmationPopup.SetActive(true);
        confirmationpopupText.text = $"DO YOU WANT TO UNLOCK THE CHEST USING{ GemsToUnlock} GEMS?";
        confirmationyesButton.onClick.RemoveAllListeners();
        confirmationNoButton.onClick.RemoveAllListeners();
        confirmationyesButton.onClick.AddListener(OnyesButtonClick);


        confirmationNoButton.onClick.AddListener(OnNoButtonClick);
    }

    public void DisplayInfoPopup(string text)
    {
        infoPopup.SetActive(true);
        infoPopupText.text = text;


    }

    private void CloseConfirmationPopup()
    {
        confirmationPopup.SetActive(false);
        
        
    }

    private void CloseInfoPopup()
    {
        infoPopup.SetActive(false);
    }

    private void OnbackbuttonClick()
    {
        confirmationPopup.SetActive(false);
        lastChestController.AddButtonlisterner();

    }

    private void OnyesButtonClick()
    {
        int GemsToUnlock = lastChestController.GetSO().gemsToOpen;
        if (GemsToUnlock > ResourcesDisplay.Instance.GetGems())
        {
            DisplayInfoPopup("YOU DON'T HAVE ENOUGH GEMS");
            return;
        }
        lastChestController.UnlockChest();

        ResourcesDisplay.Instance.AddGems(GemsToUnlock * -1);
        CloseConfirmationPopup();
    }

    private void OnNoButtonClick()
    {
        if (ChestGeneration.Instance.IsTimerRunning())
        {
            DisplayInfoPopup("THE TIMER IS ALREADY RUNNING");
            return;
        }
        lastChestController.WaitForConfirmation();
        CloseConfirmationPopup();
    }
}
