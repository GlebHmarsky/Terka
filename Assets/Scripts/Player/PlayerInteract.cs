using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
  [SerializeField] private PlantManager plantManager;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Interact();
    }
  }

  private void Interact()
  {
    int x = Mathf.FloorToInt(transform.position.x);
    int y = Mathf.FloorToInt(transform.position.y);

    Vector2Int position2d = new Vector2Int(x, y);

    Vector3Int position3d = (Vector3Int)position2d;
    TileManager tl = GameManager.instance.tileManager;
    if (tl.IsInteractable(position3d))
    {
      if (plantManager.isPlowed(position2d))
      {
        if (!plantManager.isOccupied(position2d))
        {
          Plant(position2d);
        }
      }
      else
      {
        Till(position2d);
      }
    }
  }

  private void Plant(Vector2Int position)
  {
    
    plantManager.CreatePlant(position, $"Test {position}");
  }

  private void Till(Vector2Int position)
  {
    plantManager.CreatePlowed(position);
  }


}
