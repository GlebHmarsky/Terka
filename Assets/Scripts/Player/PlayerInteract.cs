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
    // Interact with inventory's holding item
    ItemData itemData = playerManager.inventory.GetSelectedSlot().itemData;
    if (itemData && itemData.Action)
    {
      itemData.Action.PerformAction(mouseSelect.position);
    }

  }
}
