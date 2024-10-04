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
    [SerializeField] private string confirmationText;
    private ChestController lastInteractedChestController;

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
        confirmationBackButton.onClick.AddListener(CloseConfirmationPopup);
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
        lastInteractedChestController = chestController;
        confirmationPopup.SetActive(true);
        confirmationpopupText.text = confirmationText;
        confirmationyesButton.onClick.RemoveAllListeners();
        confirmationNoButton.onClick.RemoveAllListeners();
        confirmationyesButton.onClick.AddListener(() =>
        {
            chestController.UnlockChest();  
            CloseConfirmationPopup();    
        });
        confirmationNoButton.onClick.AddListener(() =>
        {
            chestController.WaitForConfirmation();  
            CloseConfirmationPopup();
            
        });

    }

    public void DisplayInfoPopup(string text)
    {
        infoPopup.SetActive(true);
        infoPopupText.text = text;


    }

    private void CloseConfirmationPopup()
    {
        confirmationPopup.SetActive(false);
        lastInteractedChestController.AddButtonlisterner();
        
    }

    private void CloseInfoPopup()
    {
        infoPopup.SetActive(false);
    }

}
