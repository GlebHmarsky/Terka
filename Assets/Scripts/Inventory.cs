using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventory
{
  public UnityEvent inventoryUpdate;

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

    public bool CanBeAdded(string itemName)
    {
      return itemName == this.itemName && count < maxAllowed;
    }

    public bool IsEmpty()
    {
      return itemName == "" && count == 0;
    }

    public void AddItem(Item item)
    {
      itemName = item.data.itemName;
      icon = item.data.icon;
      count++;
    }

    public void AddItem(string itemName, Sprite icon, int maxAllowed)
    {
      this.itemName = itemName;
      this.icon = icon;
      this.maxAllowed = maxAllowed;
      count++;
    }

    public void AddItem(Slot fromSlot)
    {
      this.itemName = fromSlot.itemName;
      this.icon = fromSlot.icon;
      this.maxAllowed = fromSlot.maxAllowed;
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
    inventoryUpdate = new UnityEvent();
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
      if (slot.itemName == item.data.itemName && slot.CanBeAdded(item.data.itemName))
      {
        slot.AddItem(item);
        inventoryUpdate.Invoke();
        return;
      }
      else if (slot.itemName == "")
      {
        slot.AddItem(item);
        inventoryUpdate.Invoke();
        return;
      }
    }
  }

  public void Remove(int index)
  {
    slots[index].RemoveItem();
    inventoryUpdate.Invoke();
  }

  public void Remove(int index, int numToRemove)
  {
    if (slots[index].count >= numToRemove)
    {
      for (int i = 0; i < numToRemove; i++)
      {
        Remove(index);
      }
    }
  }

  public void RemoveAll(int index)
  {
    int count = slots[index].count;
    for (int i = 0; i < count; i++)
    {
      Remove(index);
    }
  }

  public void MoveSlot(int fromIndex, int toIndex)
  {
    Slot fromSlot = slots[fromIndex];
    Slot toSlot = slots[toIndex];

    if (toSlot.IsEmpty() || toSlot.CanBeAdded(fromSlot.itemName))
    {
      toSlot.AddItem(fromSlot);
      fromSlot.RemoveItem();
      inventoryUpdate.Invoke();
    }
  }

}
