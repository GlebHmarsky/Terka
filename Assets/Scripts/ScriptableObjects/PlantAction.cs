using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantAction", menuName = "Scriptable Actions/PlantAction")]
public class PlantAction : ScriptableAction
{
  public override void PerformAction(Vector2Int position, InventoryManager inventoryManager)
  {
    PlantManager plantManager = GameManager.instance.plantManager;

    if (plantManager.isPlowed(position))
    {
      if (!plantManager.isOccupied(position))
      {
        inventoryManager.RemoveSelectedItem();
        plantManager.CreatePlant(position, $"Test {position}");
      }
    }

  }
}
