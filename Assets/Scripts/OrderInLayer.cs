using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayer : MonoBehaviour
{

  public SpriteRenderer playerSpriteRenderer;
  public Renderer tileRenderer;

  public Transform playerTransform;
  public Transform tileTransform;

  void Update()
  {
    if (tileTransform.position.y < playerTransform.position.y)
    {
      tileRenderer.sortingOrder = playerSpriteRenderer.sortingOrder + 1;
    }
    else
    {
      tileRenderer.sortingOrder = playerSpriteRenderer.sortingOrder - 1;
    }
  }
}
