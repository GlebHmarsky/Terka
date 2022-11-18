using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
  [System.Serializable]
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

    public bool CanBeAdded()
    {
      return count != maxAllowed;
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

  // TODO: make bool for adding 
  public void Add(CollectableType type, int amount)
  {
    foreach (var slot in slots)
    {
      if (slot.type == type && slot.CanBeAdded())
      {
        slot.count++;
        return;
      }
      else if (slot.type == CollectableType.NONE)
      {
        slot.type = type;
        slot.count++;
        return;
      }
    }
  }

}
