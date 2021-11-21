using System;
using System.Collections.Generic;
using AssetBundles;
using CustomUI;
using CustomUI.PopupWindow;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


public class MainMenuView : AssetBundleViewBase
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

    [SerializeField] private Button _loadAssetButton;
    [SerializeField] private Button _spawnAssetButton;
    [SerializeField] private RectTransform _mountRootTransform;
    [SerializeField] private AssetReference _loadPrefab;

    private List<AsyncOperationHandle<GameObject>> _adressablePrefabs = new List<AsyncOperationHandle<GameObject>>();

    public void Init(UnityAction startGame, UnityAction rewardAdRequested, UnityAction showGarage, UnityAction getDaily, UnityAction exitGame)
    {
        _buttonStart.onClick.AddListener(startGame);
        _showRewarded.onClick.AddListener(rewardAdRequested);
        _showGarage.onClick.AddListener(showGarage);
        
        _showAbout.onClick.AddListener(ShowAboutPopup);
        _aboutWindow.gameObject.SetActive(false);
        
        _dailyButton.onClick.AddListener(getDaily);
        _exitButton.onClick.AddListener(exitGame);

        _loadAssetButton.onClick.AddListener(LoadAssets);
        _spawnAssetButton.onClick.AddListener(CreatePrefab);
    }

    private void CreatePrefab()
    {
        _addressablesTime = DateTime.Now;
        var addressablePrefab = Addressables.InstantiateAsync(_loadPrefab, _mountRootTransform);
        _adressablePrefabs.Add(addressablePrefab);
        Debug.Log($"{Math.Abs(_addressablesTime.Millisecond-DateTime.Now.Millisecond)} ms. addressables instantiating");
    }

    private void LoadAssets()
    {
        _bundleTime = DateTime.Now;
        _loadAssetButton.interactable = false;
        StartCoroutine(DownloadAndSetAssetBundle());
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
        
        _loadAssetButton.onClick.RemoveAllListeners();
        _spawnAssetButton.onClick.RemoveAllListeners();

        foreach (var adressablePrefab in _adressablePrefabs)
            Addressables.ReleaseInstance(adressablePrefab);
        
        _adressablePrefabs.Clear();
        
        
    }
}