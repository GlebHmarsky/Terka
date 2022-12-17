using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantAction", menuName = "Scriptable Actions/PlantAction")]
public class PlantAction : ScriptableAction
{
  public override void PerformAction(Vector2Int position, InventoryManager inventoryManager)
  {
    inventoryManager.RemoveSelectedItem();
    GameManager.instance.plantManager.CreatePlant(position, $"Test {position}");
  }
}
