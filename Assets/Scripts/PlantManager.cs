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

  public void CreatePlant(Vector2Int position, string name)
  {
    GameObject plantGameObject = Instantiate(plantPrefab, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
    plants.Add(plantGameObject);

    Plant plant = plantGameObject.GetComponent<Plant>();
    plant.plantName = name;
    plant.position = position;
  }
  public void CreatePlowed(Vector2Int position)
  {
    GameObject plowedGameObject = Instantiate(plowedPrefab, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
    this.plowed.Add(plowedGameObject);

    Plowed plowed = plowedGameObject.GetComponent<Plowed>();
    plowed.position = position;
  }

  public bool isOccupied(Vector2Int position)
  {
    GameObject obj = plants.Find(x => FindPlaceableObject(x, position));
    return !(obj is null);
  }
  public bool isPlowed(Vector2Int position)
  {
    GameObject obj = plowed.Find(x => FindPlaceableObject(x, position));
    return !(obj is null);
  }

  private bool FindPlaceableObject(GameObject obj, Vector2Int position)
  {
    IPlaceableObject placeableObject = obj.GetComponent<IPlaceableObject>();
    return placeableObject.position == position;
  }

}
