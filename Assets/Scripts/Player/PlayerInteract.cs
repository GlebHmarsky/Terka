using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(MouseSelect))]
public class PlayerInteract : MonoBehaviour
{
  private PlayerManager playerManager;
  private MouseSelect mouseSelect;

  private void Start()
  {
    playerManager = GetComponent<PlayerManager>();
    mouseSelect = GetComponent<MouseSelect>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      Interact();
    }
  }

  private void Interact()
  {
    // First of all check if there is some actionable GameObject in scene
    Plant plant = GameManager.instance.plantManager.GetPlant(mouseSelect.position);
    if (plant != null)
    {
      if (plant.CanBeHarvested())
      {
        plant.Harvest();
        return;
      }
    }

    // Second check the in world objects (like chest)
    Chest chest = GameManager.instance.worldObjectManager.GetChest(mouseSelect.position);
    if (chest != null)
    {
      GameManager.instance.uiManger.OpenChestInventory(chest);
      return;
    }

    // After all, we go to inventory and perform item that we hold
    ItemData itemData = playerManager.inventory.GetSelectedSlot().itemData;
    if (itemData && itemData.Action)
    {
      itemData.Action.PerformAction(mouseSelect.position, playerManager.inventory);
    }

  }
}
