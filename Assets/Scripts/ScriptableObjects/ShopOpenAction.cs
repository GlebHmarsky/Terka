using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopOpenAction", menuName = "Scriptable Actions/ShopOpenAction")]
public class ShopOpenAction : ScriptableObjectAction
{
  public override void PerformAction(GameObject gameObject)
  {
    Shop shop = gameObject.GetComponent<Shop>();
    if (shop != null)
    {
      GameManager.instance.uiManger.OpenShop(shop);
      return;
    }
  }
}
