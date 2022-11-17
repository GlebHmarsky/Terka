using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IPlaceableObject
{
  public int posX { get; set; }
  public int posY { get; set; }
  public string plantName;

  public Plant(int posX, int posY, string name)
  {
    this.posX = posX;
    this.posY = posY;
    this.plantName = name;
  }


}
