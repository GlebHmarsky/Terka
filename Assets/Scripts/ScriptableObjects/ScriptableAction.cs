using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FIXME: Needs good naming for that
public abstract class ScriptableAction : ScriptableObject
{
  /// <summary>
  /// Perform some action
  /// </summary>
  /// <param name="position"></param>
  /// <param name="inventoryManager"></param>
  /// <returns>False if there some problem and action work not as planed. True otherwise</returns>
  public abstract void PerformAction(Vector2Int position, InventoryManager inventoryManager);
}
