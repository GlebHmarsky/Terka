using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
  public List<Plant> plants;
  public List<Plowed> plowed;

  public Plant plantPrefab;
  public Plowed plowedPrefab;


  void Start()
  {
    plants = new List<Plant>();
    plowed = new List<Plowed>();
  }

  public void CreatePlant(Vector2Int position, string name, PlantData data)
  {
    Plant plant = Instantiate(plantPrefab, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
    plants.Add(plant);

    plant.data = data;
    plant.plantName = name;
    plant.position = position;
  }

  public void CreatePlowed(Vector2Int position)
  {
    Plowed plowedGameObject = Instantiate(plowedPrefab, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
    this.plowed.Add(plowedGameObject);

    plowedGameObject.position = position;
  }

  public bool isOccupied(Vector2Int position)
  {
    return !(GetPlant(position) is null);
  }

  public bool isPlowed(Vector2Int position)
  {
    return !(GetPlowed(position) is null);
  }

  public Plant GetPlant(Vector2Int position)
  {
    return plants.Find(x => FindPlaceableObject(x.GetComponent<IPlaceableObject>(), position));
  }

  public Plowed GetPlowed(Vector2Int position)
  {
    return plowed.Find(x => FindPlaceableObject(x.GetComponent<IPlaceableObject>(), position));
  }

  private bool FindPlaceableObject(IPlaceableObject obj, Vector2Int position)
  {
    return obj.position == position;
  }

}
