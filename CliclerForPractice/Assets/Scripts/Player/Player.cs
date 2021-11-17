using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerWallet))]
public class Player : MonoBehaviour
{
   [SerializeField] private CakeCollector _cakeCollector;
   
   private PlayerWallet _playerWallet;

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
}

