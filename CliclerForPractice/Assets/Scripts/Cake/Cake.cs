using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] private int _profit;

    private CakeLayer[] _layers;
    private int _createdLayers;

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
