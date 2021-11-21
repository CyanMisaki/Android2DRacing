using RewardSystem;
using UnityEngine;

public class MVCCurrencyController : BaseController
{
    private readonly ProfilePlayer _profilePlayer;
    private readonly Transform _placeForUI;
    private MVCCurrencyView _mvcCurrencyView;

    public MVCCurrencyController(ProfilePlayer profilePlayer, ResourcePath resourcePath, Transform placeForUI)
    {
        _profilePlayer = profilePlayer;
        _placeForUI = placeForUI;
        
        var prefab = ResourceLoader.LoadObject<MVCCurrencyView>(resourcePath);
        _mvcCurrencyView = Object.Instantiate(prefab, placeForUI);
        AddGameObjects(_mvcCurrencyView.gameObject);
        
        _profilePlayer.Diamond.SubscribeOnChange(v => _mvcCurrencyView.Diamond = v);
        _profilePlayer.Wood.SubscribeOnChange(v => _mvcCurrencyView.Wood = v);

        _mvcCurrencyView.Diamond = _profilePlayer.Diamond.Value;
        _mvcCurrencyView.Wood = _profilePlayer.Wood.Value;
    }
    
    
}