using System;
using CustomUI;
using CustomUI.PopupWindow;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
    
    [SerializeField] private Button _dailyButton;
    [SerializeField] private Button _exitButton;
        
    public void Init(UnityAction startGame, UnityAction rewardAdRequested, UnityAction showGarage, UnityAction getDaily, UnityAction exitGame)
    {
        _buttonStart.onClick.AddListener(startGame);
        _showRewarded.onClick.AddListener(rewardAdRequested);
        _showGarage.onClick.AddListener(showGarage);
        
        _showAbout.onClick.AddListener(ShowAboutPopup);
        _aboutWindow.gameObject.SetActive(false);
        
        _dailyButton.onClick.AddListener(getDaily);
        _exitButton.onClick.AddListener(exitGame);
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
        _exitButton.onClick.RemoveAllListeners();
        _dailyButton.onClick.RemoveAllListeners();
    }
}