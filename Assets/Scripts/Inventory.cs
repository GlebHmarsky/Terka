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
    public string itemName;
    public Sprite icon;
    public int count;
    public int maxAllowed;

    public Slot()
    {
      itemName = "";
      count = 0;
      maxAllowed = 99;
    }

    public bool CanBeAdded()
    {
      return count != maxAllowed;
    }

    public void AddItem(Item item)
    {
      itemName = item.data.itemName;
      icon = item.data.icon;
      count++;
    }

    public void RemoveItem()
    {
      if (count > 0)
      {
        count--;
        if (count == 0)
        {
          icon = null;
          itemName = "";
        }
      }
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
  public void Add(Item item)
  {
    foreach (var slot in slots)
    {
      if (slot.itemName == item.data.itemName && slot.CanBeAdded())
      {
        slot.AddItem(item);
        return;
      }
      else if (slot.itemName == "")
      {
        slot.AddItem(item);
        return;
      }
    }
  }
  public void Remove(int index)
  {
    slots[index].RemoveItem();
  }

}
