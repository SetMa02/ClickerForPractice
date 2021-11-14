using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePlace : MonoBehaviour
{
    [SerializeField] private GameObject _cakePrefab;

    private void Start()
    {
        SetCake(_cakePrefab);
    }

    public void SetCake(GameObject cake)
    {
        _cakePrefab = Instantiate(cake, transform);
    }

    public void RemoveCake(GameObject cake)
    {
        Destroy(cake);
    }
}
