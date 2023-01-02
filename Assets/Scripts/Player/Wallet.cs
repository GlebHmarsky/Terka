using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
  public int money { get; private set; } = 0;
  public event Action moneyChanged;
  
  public void Add(int money)
  {
    if (money < 0)
    {
      Debug.LogWarning($"Money to add was negative ({money})");
      return;
    }
    this.money += money;
    moneyChanged();
  }

  public void Take(int money)
  {
    if (money < 0)
    {
      Debug.LogWarning($"Money to deduct was negative ({money})");
      return;
    }
    this.money -= money;
    moneyChanged();
  }
}
