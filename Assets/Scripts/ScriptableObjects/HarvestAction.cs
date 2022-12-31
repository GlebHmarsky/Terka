using UnityEngine;

[CreateAssetMenu(fileName = "HarvestAction", menuName = "Scriptable Actions/HarvestAction")]
public class HarvestAction : ScriptableObjectAction
{
  public override void PerformAction(GameObject gameObject)
  {
    Plant plant = gameObject.GetComponent<Plant>();
    if (!plant) return;
    if (!plant.CanBeHarvested()) return;

    GameManager.instance.player.inventory.Add(InventoryName.Toolbar, plant.data.fruit, Random.Range(2, 5));
    plant.DowngradeStage();
  }
}
