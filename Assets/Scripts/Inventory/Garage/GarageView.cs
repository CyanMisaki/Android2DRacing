using System;
using System.Collections.Generic;
using Inventory.Items;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Inventory.Garage
{
    public class GarageView : MonoBehaviour
    {
        [SerializeField] private Transform _canvas;
        [SerializeField] private Font _font;

        [SerializeField] private Button _startGame;
        
        private float _alingmentOffset = 265;
        private List<Button> _buttons;

        public void Init(ItemsRepository repository, UnityAction<IItem> equip, UnityAction exit)
        {
            _alingmentOffset = 265;
            _buttons = new List<Button>();
            
            foreach (var item in repository.Items)
            {
                var newButton = new GameObject($"{item.Value.ID}", typeof(Image), typeof(Button), typeof(LayoutElement));
                newButton.transform.SetParent(_canvas);

                newButton.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                newButton.transform.SetParent(newButton.transform);
                var rect = newButton.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(400, 100);
                rect.localPosition = new Vector3(0,_alingmentOffset,0);
                
                _alingmentOffset -= 120;

                var newText = new GameObject($"{item.Value.ID}.text", typeof(Text));
                newText.transform.SetParent(newButton.transform);
               
                var text = newText.GetComponent<Text>();
                text.text = item.Value.Info.Title;
                text.font = _font;
                text.color=Color.white;
                text.fontSize = 40;
                text.alignment = TextAnchor.MiddleCenter;
                
                var rt = newText.GetComponent<RectTransform>();
                rt.anchorMin = new Vector2(0, 0);
                rt.localPosition = Vector3.zero;

                var button = newButton.GetComponent<Button>();
                button.onClick.AddListener(() => ButtonIsPressed(item.Value, equip));
                
                _buttons.Add(button);
            }
            
            _startGame.onClick.AddListener(exit);
        }
       private void ButtonIsPressed(IItem itemValue, UnityAction<IItem> equip)
       {
           equip?.Invoke(itemValue);
       }

       private void OnDestroy()
       {
           _startGame.onClick.RemoveAllListeners();
           
           foreach (var button in _buttons)
           {
               button.onClick.RemoveAllListeners();
           }
       }
    }

    
}