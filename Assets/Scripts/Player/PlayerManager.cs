using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
public class PlayerManager : MonoBehaviour
{
  [HideInInspector] public InventoryManager inventory;

  void Awake()
  {
    inventory = GetComponent<InventoryManager>();
  }

  public Item DropItem(ItemData itemData)
  {
    Vector2 spawnLocation = transform.position;

    // Yeah, there is Random.insideUnitCircle - but it can return (0,0)
    // i need a garantee that that flew some away with a little random
    // with this params it should go on right top corner
    Vector2 spawnOffset = (new Vector2(Random.Range(4f, 7f), Random.Range(1f, 3f)).normalized) * 1.5f;

    Item droppedItem = GameManager.instance.itemManager.CreateItem(itemData, spawnLocation + spawnOffset, Quaternion.identity);
    droppedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    return droppedItem;
  }

  public void DropItem(ItemData itemData, int numToDrop)
  {
    var item = DropItem(itemData);
    item.count = numToDrop;
  }
}
