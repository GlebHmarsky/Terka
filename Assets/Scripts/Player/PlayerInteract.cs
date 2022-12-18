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

    Vector3Int position3d = (Vector3Int)position2d;
    TileManager tl = GameManager.instance.tileManager;
    PlantManager plantManager = GameManager.instance.plantManager;
    if (tl.IsInteractable(position3d))
    {
      if (plantManager.isPlowed(position2d))
      {
        if (!plantManager.isOccupied(position2d))
        {
          Plant(position2d);
        }
      }
      else
      {
        Till(position2d);
      }
    }
  }

  private void Plant(Vector2Int position)
  {
    Item item = playerManager.inventory.GetSelectedSlot().GetItem();
    if (item)
    {
      item.data.Action.PerformAction(position, playerManager.inventory);
    }
  }

  private void Till(Vector2Int position)
  {
    Item item = playerManager.inventory.GetSelectedSlot().GetItem();
    if (item)
    {
      item.data.Action.PerformAction(position, playerManager.inventory);
    }    
  }


}
