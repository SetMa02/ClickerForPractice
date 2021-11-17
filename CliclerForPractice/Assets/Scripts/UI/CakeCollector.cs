using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class CakeCollector : MonoBehaviour
{
    [SerializeField] private CakePlace _cakePlace;
    [SerializeField] private Button _collectButton;

    private CanvasGroup _canvasGroup;
    private Cake _targetCake;

    public event UnityAction<Cake> CaleCollected;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Close();
    }

    private void OnCakeReadyForCollection(Cake cake)
    {
        _targetCake = cake;
        Open();
    }

    private void Open()
    {
        _canvasGroup.alpha = 1;
    }
    
    private void Close()
    {
        _canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _cakePlace.CakeReadyForCollection += OnCakeReadyForCollection;
        _collectButton.onClick.AddListener(CollectCake);
    }

    private void OnDisable()
    {            
        _cakePlace.CakeReadyForCollection -= OnCakeReadyForCollection;
        _collectButton.onClick.RemoveListener(CollectCake);

    }
    
    private void CollectCake()
    {
        Close();
        CaleCollected?.Invoke(_targetCake);
        
    }
}
