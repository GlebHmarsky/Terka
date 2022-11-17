using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IPlaceableObject
{
  public Vector2Int position { get; set; }
  public string plantName;

  public Plant(Vector2Int position, string name)
  {
    this.position = position;
    this.plantName = name;
  }
}
