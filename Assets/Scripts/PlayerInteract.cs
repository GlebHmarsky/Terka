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
      Vector3Int position = new Vector3Int((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y), 0);
      TileManager tl = GameManager.instance.tileManager;
      if (tl.IsInteractable(position))
      {
        tl.SetInteracted(position);
      }
    }
  }
}
