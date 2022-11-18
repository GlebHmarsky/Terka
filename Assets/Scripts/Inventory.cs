using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
  public class Slot
  {
    public CollectableType type;
    public int count;
    public int maxAllowed;

    public Slot()
    {
      type = CollectableType.NONE;
      count = 0;
      maxAllowed = 99;
    }
  }

  public List<Slot> slots = new List<Slot>();

  public Inventory(int numSlots)
  {
    for (int i = 0; i < numSlots; i++)
    {
      slots.Add(new Slot());
    }
  }

  // TODO: make bool for additing 
  public void Add(CollectableType type, int amount)
  { 
    
  }

}
