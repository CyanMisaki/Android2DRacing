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
        
    public void Init(UnityAction startGame, UnityAction rewardAdRequested)
    {
        _buttonStart.onClick.AddListener(startGame);
        _showRewarded.onClick.AddListener(rewardAdRequested);
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _showRewarded.onClick.RemoveAllListeners();
    }
}