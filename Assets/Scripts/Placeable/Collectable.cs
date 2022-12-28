using System.Collections;
using System.Collections.Generic;
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
        if (!GameManager.instance.player.inventory.Add(InventoryName.Toolbar, item.data))
        {
          // item don't fit
          return;
        }
        Destroy(gameObject);
      }
    }
  }
}
