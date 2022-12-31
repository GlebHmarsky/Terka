using UnityEngine;

public class Chest : MonoBehaviour, IPlaceableObject
{
  public Inventory inventory;
  public int inventorySize;

  public Vector2Int position { get; set; }

  void Awake()
  {
    inventory = new Inventory(inventorySize);
  }

}
