using UnityEngine;
using TMPro;

public class Money_UI : MonoBehaviour
{
  public Wallet wallet;
  public TMP_Text moneyText;
  public string formatString = "00000";

  void Start()
  {
    UpdateMoney();

    wallet.moneyChanged += UpdateMoney;
  }

  public void UpdateMoney()
  {
    moneyText.text = wallet.money.ToString(formatString);
  }
}
