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
    // PlantManager plantManager = GameManager.instance.plantManager;

    ItemData itemData = playerManager.inventory.GetSelectedSlot().itemData;
    if (itemData)
    {
      itemData.Action.PerformAction(position2d, playerManager.inventory);
    }

    // if (tl.IsInteractable(position3d))
    // {
    //   Debug.Log($"Before all checks{position2d}");
    //   if (plantManager.isPlowed(position2d))
    //   {
    //     Debug.Log($"In is plowed");
    //     if (!plantManager.isOccupied(position2d))
    //     {
    //       Debug.Log($"Before plant");
    //       Plant(position2d);
    //     }
    //   }
    //   else
    //   {
    //     Debug.Log($"Tilling");
    //     Till(position2d);
    //   }
    // }
  }
}
