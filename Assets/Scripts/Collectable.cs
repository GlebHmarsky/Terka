using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
  public CollectableType type;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      Destroy(gameObject);
    }
  }
}

public enum CollectableType
{
  NONE, CRATE_YELLOW
}