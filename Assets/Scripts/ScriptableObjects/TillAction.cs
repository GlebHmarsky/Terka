using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TillAction", menuName = "Scriptable Actions/TillAction")]
public class TillAction : ScriptableAction
{
  public override void PerformAction(Vector2Int position, InventoryManager inventoryManager)
  {    
    GameManager.instance.plantManager.CreatePlowed(position);
  }
  public void PerformAction(Vector2Int position)
  {    
    GameManager.instance.plantManager.CreatePlowed(position);
  }
}
