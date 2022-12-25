using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConstructAction", menuName = "Scriptable Actions/ConstructAction")]
public class ConstructAction : ScriptableItemAction
{
  public override void PerformAction(Vector2Int position, InventoryManager inventoryManager)
  {
    WorldObjectManager wom = GameManager.instance.worldObjectManager;
    
    if (wom.isOccupied(position)) return;
    
    wom.CreateChest(position);
    inventoryManager.RemoveSelectedItem();
  }
}
