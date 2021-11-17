using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _bakedCakes;

    public int BakedCakes => _bakedCakes;

    public void AddCakeProfit(int amount)
    {
        _bakedCakes += amount;
    }

    public void WithdrawCakes(int amount)
    {
        _bakedCakes -= amount;
    }
}
