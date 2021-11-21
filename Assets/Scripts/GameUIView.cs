using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUIView : MonoBehaviour
{
    [SerializeField] private Button _startFight;
    public Action OnFightRequested;

    private void Awake()
    {
        _startFight.onClick.AddListener(()=>OnFightRequested?.Invoke());
    }
}