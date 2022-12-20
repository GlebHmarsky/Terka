using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TillAction", menuName = "Scriptable Actions/TillAction")]
public class TillAction : ScriptableAction
{
  public override void PerformAction(Vector2Int position, InventoryManager inventoryManager)
  {
    Vector3Int position3d = (Vector3Int)position;
    TileManager tl = GameManager.instance.tileManager;
    PlantManager plantManager = GameManager.instance.plantManager;

    if (tl.IsInteractable(position3d))
    {
      if (plantManager.isPlowed(position)) return;
      GameManager.instance.plantManager.CreatePlowed(position);
    }

  }
}