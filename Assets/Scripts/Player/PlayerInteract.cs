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
      RaycastTest();
    }
  }

  /// <summary>
  /// Направленно от камеры стреляет в штуки чтобы с ними взаимодействовать
  /// </summary>
  private void RaycastTest()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
    if (hit)
    {
      Debug.Log($"Ray hit: hit: {hit};\n transform: {hit.transform}; ");
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
