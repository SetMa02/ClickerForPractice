using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePlace : MonoBehaviour
{
    [SerializeField] private Cake _cakePrefab;
    [SerializeField] private ClickerZone _clickerZone;


    private void Start()
    {
        SetCake(_cakePrefab);
    }

    public void SetCake(Cake cake)
    {
        _cakePrefab = Instantiate(cake, transform);
        _clickerZone.Click += _cakePrefab.OnClick;
    }

    public void RemoveCake(GameObject cake)
    {
        _clickerZone.Click -= _cakePrefab.OnClick; 
        Destroy(cake);
        
    }
}
