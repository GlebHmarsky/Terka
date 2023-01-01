using UnityEngine;

[CreateAssetMenu(fileName = "PlantAction", menuName = "Scriptable Actions/PlantAction")]
public class PlantAction : ScriptableItemAction
{
  public override void PerformAction(Vector2Int position)
  {
    InventoryManager inventoryManager = GameManager.instance.playerManager.inventory;
    PlantManager plantManager = GameManager.instance.plantManager;

    if (plantManager.isPlowed(position))
    {
      if (plantManager.isOccupied(position)) return;

      // FIXME: следует получить слот сразу,
      // но у нас проблема что если вызвать голый ремув у слота, ui не узнает об этом. Это бы как-то поправить имхо.
      Inventory.Slot slot = inventoryManager.GetSelectedSlot();
      plantManager.CreatePlant(position, $"Test {position}", slot.itemData.plantSeed);
      inventoryManager.RemoveSelectedItem();
    }
  }
}
