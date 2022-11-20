using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  public Inventory inventory;

  void Awake()
  {
    inventory = new Inventory(21);
  }

  public void DropItem(Item item)
  {
    Vector2 spawnLocation = transform.position;

    // Yeah, there is Random.insideUnitCircle - but it can return (0,0)
    // i need a garantee that that flew some away with a little random
    // with this params it should go on right top corner
    Vector2 spawnOffset = (new Vector2(Random.Range(4f, 7f), Random.Range(1f, 3f)).normalized) * 1.5f;

    Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
    droppedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
  }
  public void DropItem(Item item, int numToDrop)
  {
    for (int i = 0; i < numToDrop; i++)
    {
      DropItem(item);
    }
  }
}
