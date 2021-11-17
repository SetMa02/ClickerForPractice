using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
   [SerializeField] private List<CakeShopItem> _cakes;
   [SerializeField] private Player _player;
   [SerializeField] private Item _template;
   [SerializeField] private Transform _itamContainer;

   private void Start()
   {
      for (int i = 0; i <_cakes.Count; i++)
      {
         AddItem(_cakes[i]);
      }
   }

   private void AddItem(CakeShopItem cakeItem)
   {
      Item item = Instantiate(_template, _itamContainer);
      InitializeItem(item,cakeItem);
   }

   private void InitializeItem(Item item, CakeShopItem cakeItem)
   {
      item.SetCake(cakeItem);
      item.SellButtonClick += OnSellBtnClick;
      item.name = _template.name + (transform.childCount + 1);
   }

   private void OnSellBtnClick(CakeShopItem cakeItem, Item item)
   {
      TrySellCake(cakeItem, item);
   }

   private void TrySellCake(CakeShopItem cakeItem, Item item)
   {
      if (_player.ChekSalvancy(cakeItem.Price))
      {
         _player.BuyCake(cakeItem);
         cakeItem.Buy();
         UnsbscrbiteItem(item);
      }
   }

   private void UnsbscrbiteItem(Item item)
   {
      item.SellButtonClick -= OnSellBtnClick;
   }
   
}
