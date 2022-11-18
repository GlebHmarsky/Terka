using System;
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
    public Sprite icon;
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

    public void AddItem(Collectable item)
    {
      type = item.type;
      icon = item.icon;
      count++;
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



  // TODO: make bool for adding (if there is no place to add we should not add it and return false - flag for not added)
  public void Add(Collectable item)
  {
    foreach (var slot in slots)
    {
      if (slot.type == item.type && slot.CanBeAdded())
      {
        slot.AddItem(item);
        return;
      }
      else if (slot.type == CollectableType.NONE)
      {
        slot.AddItem(item);
        return;
      }
    }
  }

}
