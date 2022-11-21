using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plowed : MonoBehaviour, IPlaceableObject
{
  public Vector2Int position { get; set; }
  public int posY { get; set; }

  public Plowed(Vector2Int position)
  {
    this.position = position;
  }
}
