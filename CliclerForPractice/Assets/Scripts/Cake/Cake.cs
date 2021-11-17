using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cake : MonoBehaviour
{
    [SerializeField] private int _profit;

    private CakeLayer[] _layers;
    private int _createdLayers;

    public event UnityAction CakeDone;
    public int Profit => _profit; 
    public bool Done => _createdLayers == _layers.Length;
    private void Start()
    {
        _layers = GetComponentsInChildren<CakeLayer>();
        _createdLayers = 0;
    }

    public void OnClick()
    {
        if (Done == false)
        {
            if (TryBakeLayer())
            {
                if (Done == true)
                {
                    CakeDone?.Invoke();
                    Debug.Log("cake is ready");
                }
            }
        }
    }

    private bool TryBakeLayer()
    {
        CakeLayer cakeLayer = _layers[_createdLayers];
        
        cakeLayer  .IncreaseCookingProgress();
        if (cakeLayer.TryCookLayer())
        {
            _createdLayers++;
            return true;
        }
        else
        {
            return false;
        }
    }
}
