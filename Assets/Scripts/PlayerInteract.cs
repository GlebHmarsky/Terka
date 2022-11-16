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

    Vector3Int position = new Vector3Int(x, y, 0);
    TileManager tl = GameManager.instance.tileManager;
    if (tl.IsInteractable(position))
    {
      tl.SetInteracted(position);
      plantManager.CreatePlant(x,y,$"Test {x}{y}");
    }
  }
}
