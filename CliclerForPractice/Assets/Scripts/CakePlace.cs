using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CakePlace : MonoBehaviour
{
    [SerializeField] private Cake _cakePrefab;
    [SerializeField] private ClickerZone _clickerZone;

    public event UnityAction<Cake> CakeReadyForCollection;
    
    private void Start()
    {
        SetCake(_cakePrefab);
    }

    public void SetCake(Cake cake)
    {
        _cakePrefab = Instantiate(cake, transform);
        _cakePrefab.CakeDone += OnCakeDone;
        _clickerZone.Click += _cakePrefab.OnClick;
    }

    public void RemoveCake(GameObject cake)
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
