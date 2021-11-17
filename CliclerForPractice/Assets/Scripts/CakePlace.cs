using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CakePlace : MonoBehaviour
{
    [SerializeField] private ClickerZone _clickerZone;
    
    private Cake _cakePrefab;

    public event UnityAction<Cake> CakeReadyForCollection;
    
    
    public void SetCake(Cake cake)
    {
        if(_cakePrefab != null)
            RemoveCake(_cakePrefab);
        
        _cakePrefab = Instantiate(cake, transform);
        _cakePrefab.CakeDone += OnCakeDone;
        _clickerZone.Click += _cakePrefab.OnClick;
    }

    public void RemoveCake(Cake cake)
    {
        _clickerZone.Click -= _cakePrefab.OnClick; 
        _cakePrefab.CakeDone -= OnCakeDone;
        Destroy(cake);
        
    }

    private void OnCakeDone()
    {
        CakeReadyForCollection?.Invoke(_cakePrefab);
    }
}
