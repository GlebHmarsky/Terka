using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerInteract : MonoBehaviour
{
  private PlayerManager playerManager;

  private void Start()
  {
    playerManager = GetComponent<PlayerManager>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Interact();
    }
  }

  private void Interact()
  {
    int x = Mathf.FloorToInt(transform.position.x);
    int y = Mathf.FloorToInt(transform.position.y);

    Vector2Int position2d = new Vector2Int(x, y);

    ItemData itemData = playerManager.inventory.GetSelectedSlot().itemData;
    if (itemData)
    {
      itemData.Action.PerformAction(position2d, playerManager.inventory);
    }
    
  }
}
