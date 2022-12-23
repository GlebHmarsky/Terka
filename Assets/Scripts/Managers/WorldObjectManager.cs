using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectManager : MonoBehaviour
{
  public List<Chest> chests;

  public Chest chestPrefab;

  void Start()
  {
    chests = new List<Chest>();
  }

  public void CreateChest(Vector2Int position)
  {
    Chest chest = Instantiate(chestPrefab, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
    chests.Add(chest);

    chest.position = position;
  }

  public bool isOccupied(Vector2Int position)
  {
    return GetChest(position) != null;
  }

  public Chest GetChest(Vector2Int position)
  {
    return chests.Find(x => FindPlaceableObject(x.gameObject, position));
  }

  // FIXME: тут должен прокидываться не gameobject а непосредственно интерфейс IPlaceableObject, аналогичный трабл в plantManager
  private bool FindPlaceableObject(GameObject obj, Vector2Int position)
  {
    IPlaceableObject placeableObject = obj.GetComponent<IPlaceableObject>();
    return placeableObject.position == position;
  }
}
