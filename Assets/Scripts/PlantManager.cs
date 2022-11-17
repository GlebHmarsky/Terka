using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
  public List<GameObject> plants;
  public List<GameObject> plowed;

  public GameObject plantPrefab;
  public GameObject plowedPrefab;


  void Start()
  {
    plants = new List<GameObject>();
    plowed = new List<GameObject>();
  }

  public void CreatePlant(int posX, int posY, string name)
  {
    GameObject plantGameObject = Instantiate(plantPrefab, new Vector3(posX + 0.5f, posY + 0.5f, 0), Quaternion.identity);
    plants.Add(plantGameObject);

    Plant plant = plantGameObject.GetComponent<Plant>();
    plant.plantName = name;
    plant.posX = posX;
    plant.posY = posY;

  }
  public void CreatePlowed(int posX, int posY, string name)
  {
    GameObject plowedGameObject = Instantiate(plowedPrefab, new Vector3(posX + 0.5f, posY + 0.5f, 0), Quaternion.identity);
    this.plowed.Add(plowedGameObject);

    Plowed plowed = plowedGameObject.GetComponent<Plowed>();
    plowed.posX = posX;
    plowed.posY = posY;

  }
}
