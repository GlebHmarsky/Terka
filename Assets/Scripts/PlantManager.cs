using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{

  // TODO: do not use object Plant, use GameObject WITH Plant IN IT
  public List<Plant> plants;
  public GameObject prefab;



  void Start()
  {
    plants = new List<Plant>();
  }

  public void CreatePlant(int posX, int posY, string name)
  {
    plants.Add(new Plant(posX, posY, name));

    Instantiate(prefab, new Vector3(posX + 0.5f, posY + 0.5f, 0), Quaternion.identity);
  }
}
