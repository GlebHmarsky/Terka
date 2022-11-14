using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Vector3Int position = new Vector3Int((int)(transform.position.x), (int)(transform.position.y), (int)(transform.position.z));

    }
  }
}
