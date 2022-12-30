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
      if (RaycastAction()) return;
      Interact();
    }
  }

  /// <summary>
  /// Направленно от камеры стреляет в штуки чтобы с ними взаимодействовать
  /// </summary>
  private bool RaycastAction()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
    if (hit)
    {
      GameObject gameObject = hit.transform.gameObject;
      Interactable interactable = gameObject.GetComponent<Interactable>();
      if (!interactable) return false;

      interactable.Call();
      return true;
    }
    return false;
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

    // After all, we go to inventory and perform item that we hold
    ItemData itemData = playerManager.inventory.GetSelectedSlot().itemData;
    if (itemData && itemData.Action)
    {
      itemData.Action.PerformAction(mouseSelect.position, playerManager.inventory);
    }

  }
}
