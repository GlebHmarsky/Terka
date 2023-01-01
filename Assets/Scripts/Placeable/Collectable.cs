using UnityEngine;

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      Item item = GetComponent<Item>();

      if (item)
      {
        InventoryManager inventoryManager = GameManager.instance.playerManager.inventory;
        int restCount = inventoryManager.Add(InventoryName.Toolbar, item.data, item.count);
        if (restCount != 0)
        {
          // item don't fully fit 
          item.count = restCount;
          return;
        }
        Destroy(gameObject);
      }
    }
  }
}
