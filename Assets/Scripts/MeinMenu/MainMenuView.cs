using System;
using CustomUI;
using CustomUI.PopupWindow;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] 
    private CustomButton _buttonStart;
    [SerializeField] 
    private CustomButton _showRewarded;
    [SerializeField] 
    private CustomButton _showGarage;
    
    [SerializeField] 
    private CustomButton _showAbout;

    [SerializeField] private AdditionalWindow _aboutWindow;
        
    public void Init(UnityAction startGame, UnityAction rewardAdRequested, UnityAction showGarage)
    {
        _buttonStart.onClick.AddListener(startGame);
        _showRewarded.onClick.AddListener(rewardAdRequested);
        _showGarage.onClick.AddListener(showGarage);
        
        _showAbout.onClick.AddListener(ShowAboutPopup);
        _aboutWindow.gameObject.SetActive(false);
    }

    private void ShowAboutPopup()
    {
        _aboutWindow.Show();
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _showRewarded.onClick.RemoveAllListeners();
        _showGarage.onClick.RemoveAllListeners();
        _showAbout.onClick.RemoveAllListeners();
    }
}