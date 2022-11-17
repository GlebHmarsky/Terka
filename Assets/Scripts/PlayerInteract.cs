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
    Debug.Log(position3d);
    TileManager tl = GameManager.instance.tileManager;
    if (tl.IsInteractable(position3d))
    {
      // tl.SetInteracted(position3d);
      if (plantManager.isPlowed(x, y))
      {
        if (!plantManager.isOccupied(x, y))
        {
          plantManager.CreatePlant(x, y, $"Test {x} {y}");
        }
      }
      else
      {
        plantManager.CreatePlowed(x, y);
      }
    }
  }
}
