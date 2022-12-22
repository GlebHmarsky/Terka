using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
  public Inventory inventory;
  public int inventorySize;


  void Start()
  {
    inventory = new Inventory(inventorySize);
  }

  void Update()
  {

  }
}
