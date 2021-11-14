using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CakeLayer : MonoBehaviour
{
    [SerializeField] private int _clicksBeforeCooking;
  
    private SpriteRenderer _spriteRenderer;
    private Color _layerColor;

    public int CookingProgress { get; private set; }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        _layerColor = _spriteRenderer.color;
        CreateGhostLayer();
    }

    public void IncreaseCookingProgress()
    {
        CookingProgress++;
    }

    private void CreateGhostLayer()
    {
        _spriteRenderer.color = new Color(255, 255, 255, 60);
    }

    public bool TryCookLayer()
    {
        if (_clicksBeforeCooking == CookingProgress)
        {
            _spriteRenderer.color = _layerColor;
            return true;
        }
        else
        {
            return false;
        }
    }
}
