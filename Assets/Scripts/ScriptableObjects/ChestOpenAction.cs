using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestOpenAction", menuName = "Scriptable Actions/ChestOpenAction")]
public class ChestOpenAction : ScriptableObjectAction
{
  public override void PerformAction(GameObject gameObject)
  {
    Chest chest = gameObject.GetComponent<Chest>();//GameManager.instance.worldObjectManager.GetChest(position);
    if (chest != null)
    {
      GameManager.instance.uiManger.OpenChestInventory(chest);
      return;
    }
  }
}
