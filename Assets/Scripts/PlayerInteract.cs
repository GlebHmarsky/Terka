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
      int x = Mathf.CeilToInt(Mathf.Abs(transform.position.x)) * (int)Mathf.Sign(transform.position.x);
      int y = Mathf.CeilToInt(Mathf.Abs(transform.position.y)) * (int)Mathf.Sign(transform.position.y);

      Debug.Log($"{x},{y}; {transform.position.x}, {transform.position.y}");

      Vector3Int position = new Vector3Int(x, y, 0);
      TileManager tl = GameManager.instance.tileManager;
      if (tl.IsInteractable(position))
      {
        tl.SetInteracted(position);
      }
    }
  }
}
