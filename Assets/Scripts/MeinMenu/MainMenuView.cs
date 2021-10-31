using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] 
    private Button _buttonStart;
    [SerializeField] 
    private Button _showRewarded;
    [SerializeField] 
    private Button _showGarage;
        
    public void Init(UnityAction startGame, UnityAction rewardAdRequested, UnityAction showGarage)
    {
        _buttonStart.onClick.AddListener(startGame);
        _showRewarded.onClick.AddListener(rewardAdRequested);
        _showGarage.onClick.AddListener(showGarage);
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _showRewarded.onClick.RemoveAllListeners();
        _showGarage.onClick.RemoveAllListeners();
    }
}