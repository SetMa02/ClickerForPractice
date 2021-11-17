using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _profit;
    [SerializeField] private Button _sellButton;

    private CakeShopItem _cakeShopItem;

    private void CheckCakeState()
    {
        if (_cakeShopItem.IsBuy)
        {
            _sellButton.interactable = false;
            _label.text = "Продано";
        }
    }

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(CheckCakeState);
        _sellButton.onClick.AddListener(OnSellButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(CheckCakeState);
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(_cakeShopItem, this);
    }

    public event UnityAction<CakeShopItem, Item> SellButtonClick;
    
    public void SetCake(CakeShopItem cakeItem)
    {
        _cakeShopItem = cakeItem;
        RenderCake(cakeItem);
    }

    private void RenderCake(CakeShopItem cakeItem)
    {
        _label.text = cakeItem.Label;
        _price.text = cakeItem.Price.ToString();
        _icon.sprite = cakeItem.Icon;
        _profit.text = cakeItem.CakeProfit.ToString();
    }

}
