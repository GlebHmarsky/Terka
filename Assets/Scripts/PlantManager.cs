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
  public void CreatePlowed(int posX, int posY)
  {
    GameObject plowedGameObject = Instantiate(plowedPrefab, new Vector3(posX + 0.5f, posY + 0.5f, 0), Quaternion.identity);
    this.plowed.Add(plowedGameObject);

    Plowed plowed = plowedGameObject.GetComponent<Plowed>();
    plowed.posX = posX;
    plowed.posY = posY;

  }

  public bool isOccupied(int posX, int posY)
  {
    GameObject obj = plants.Find(x => FindPlaceableObject(x, posX, posY));
    return !(obj is null);
  }
  public bool isPlowed(int posX, int posY)
  {
    GameObject obj = plowed.Find(x => FindPlaceableObject(x, posX, posY));
    return !(obj is null);
  }

  private bool FindPlaceableObject(GameObject obj, int posX, int posY)
  {
    IPlaceableObject placeableObject = obj.GetComponent<IPlaceableObject>();
    return placeableObject.posX == posX && placeableObject.posY == posY;
  }

}
