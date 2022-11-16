using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
  public List<Plant> plants;

  void Start()
  {
    plants = new List<Plant>();
  }

  public void CreatePlant(int posX, int posY, string name)
  {
    plants.Add(new Plant(posX, posY, name));
  }
}
