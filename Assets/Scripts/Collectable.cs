using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
  public CollectableType type;
  public Sprite icon;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      PlayerManager playerManager = other.GetComponent<PlayerManager>();
      if (playerManager)
      {
        playerManager.inventory.Add(this);
        Destroy(gameObject);
      }
    }
  }
}

public enum CollectableType
{
  NONE, CRATE_YELLOW
}