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
      PlayerManager playerManager = other.GetComponent<PlayerManager>();
      if (playerManager)
      {
        Item item = GetComponent<Item>();

        if (item)
        {
          playerManager.inventory.Add(item);
          Destroy(gameObject);
        }
      }
    }
  }
}
