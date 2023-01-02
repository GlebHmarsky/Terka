using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
  public void SellItem()
  {
    Inventory.Slot slot = UIManger.GetSlotFromDragged();
    if (slot == null) return;

    ItemData itemToSell = slot.itemData;
    GameManager.instance.playerManager.SellItem(itemToSell, slot.count);
  }
}
