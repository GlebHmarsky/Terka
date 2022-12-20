using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FIXME: Needs good naming for that
public abstract class ScriptableAction : ScriptableObject
{
  /// <summary>
  /// Perform some action
  /// </summary>
  public abstract void PerformAction(Vector2Int position, InventoryManager inventoryManager);
}
