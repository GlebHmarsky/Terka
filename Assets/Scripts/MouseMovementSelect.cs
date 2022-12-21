using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementSelect : MonoBehaviour
{
  public Vector3 position;
  void Update()
  {
    OnMouseMovement();
  }

  void OnMouseMovement()
  {
    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    position = new Vector3(Mathf.FloorToInt(worldPosition.x) + 0.5f, Mathf.FloorToInt(worldPosition.y) + 0.5f, 0);
    transform.position = position;
  }
}
