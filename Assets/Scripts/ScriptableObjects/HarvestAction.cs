using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HarvestAction", menuName = "Scriptable Actions/HarvestAction")]
public class HarvestAction : ScriptablePlantAction
{
  public override void PerformAction(Plant plant)
  {
    GameManager.instance.player.inventory.Add("Toolbar", plant.data.fruit, Random.Range(2, 5));
    plant.DowngradeStage();
  }
}
