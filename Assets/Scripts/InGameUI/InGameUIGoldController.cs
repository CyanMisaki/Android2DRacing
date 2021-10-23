using Tools;
using UnityEngine;

namespace InGameUI
{
    public class InGameUIGoldController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/goldUI"};
        private InGameUIGoldView _view;
        private SubscriptionProperty<int> _gold;

        private readonly Transform _placeForUI;
        
        public InGameUIGoldController(SubscriptionProperty<int> gold, Transform placeForUI)
        {
            _gold = gold;
            _placeForUI = placeForUI;
            
            _view = LoadView();
  
            gold.SubscribeOnChange(ChangeGoldValue);
            gold.Value = 100;
        }
    
        protected override void OnDispose()
        {
            _gold.UnSubscriptionOnChange(ChangeGoldValue);
            
            base.OnDispose();
        }

        private InGameUIGoldView LoadView()
        {
            var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), _placeForUI,false);
            AddGameObjects(objView);
        
            return objView.GetComponent<InGameUIGoldView>();
        }
        
        private void ChangeGoldValue(int value)
        {
            _view.ChangeGoldStatus(value);
        }
    }
}