using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      int x = Mathf.FloorToInt(transform.position.x);
      int y = Mathf.FloorToInt(transform.position.y);

      Vector3Int position = new Vector3Int(x, y, 0);
      TileManager tl = GameManager.instance.tileManager;
      if (tl.IsInteractable(position))
      {
        tl.SetInteracted(position);
      }
    }
  }
}
