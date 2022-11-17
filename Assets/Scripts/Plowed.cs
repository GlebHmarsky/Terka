using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plowed : MonoBehaviour, IPlaceableObject
{
  public int posX { get; set; }
  public int posY { get; set; }

  public Plowed(int posX, int posY, string name)
  {
    this.posX = posX;
    this.posY = posY;
  }

}
