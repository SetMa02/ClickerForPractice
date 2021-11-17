using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerWallet))]
public class Player : MonoBehaviour
{
   [SerializeField] private CakeCollector _cakeCollector;
   
   private PlayerWallet _playerWallet;
   public event UnityAction<Cake> CakeBought;

   private void OnEnable()
   {
      _cakeCollector.CaleCollected += OnCakeCollected;
   }

   private void OnDisable()
   {
      _cakeCollector.CaleCollected -= OnCakeCollected;

   }

   private void OnCakeCollected(Cake cake)
   {
      _playerWallet.AddCakeProfit(cake.Profit);
   }

   private void Start()
   {
      _playerWallet = GetComponent<PlayerWallet>();
   }
   
   public bool ChekSalvancy(int price)
   {
      return _playerWallet.BakedCakes >= price;
   }

   public void BuyCake(CakeShopItem cakeItem)
   {
      _playerWallet.WithdrawCakes(cakeItem.Price);
      CakeBought?.Invoke(cakeItem.Cake);
   }
}

