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
    public ItemData itemData;
    public Sprite icon;
    public int count;
    public int maxAllowed;

    public Slot()
    {
      itemData = null;
      count = 0;
      maxAllowed = 99;
    }

    public bool CanBeAdded(ItemData itemData)
    {
      return itemData == this.itemData && count < maxAllowed;
    }

    public bool IsEmpty()
    {
      return itemData == null && count == 0;
    }

    public void AddItem(ItemData itemData)
    {
      this.itemData = itemData;
      icon = itemData.icon;
      count++;
    }

    public void AddItem(ItemData itemData, Sprite icon, int maxAllowed)
    {
      this.itemData = itemData;
      this.icon = icon;
      this.maxAllowed = maxAllowed;
      count++;
    }

    public void AddItem(Slot fromSlot)
    {
      this.itemData = fromSlot.itemData;
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
          itemData = null;
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
  public void Add(ItemData itemData)
  {
    foreach (var slot in slots)
    {
      if (slot.itemData == itemData && slot.CanBeAdded(itemData))
      {
        slot.AddItem(itemData);
        inventoryUpdate.Invoke();
        return;
      }
    }
    foreach (var slot in slots)
    {
      if (!slot.itemData)
      {
        slot.AddItem(itemData);
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

  public void MoveSlot(int fromIndex, int toIndex, Inventory toInventory)
  {
    Slot fromSlot = slots[fromIndex];
    Slot toSlot = toInventory.slots[toIndex];

    if (toSlot.IsEmpty() || toSlot.CanBeAdded(fromSlot.itemData))
    {
      toSlot.AddItem(fromSlot);
      fromSlot.RemoveItem();
      this.inventoryUpdate.Invoke();

      // Invoke event if there second inventory that we moving to slot
      if (toInventory != this)
      {
        toInventory.inventoryUpdate.Invoke();
      }
    }
  }

  public void MoveSlot(int fromIndex, int toIndex, Inventory toInventory, int numToMove)
  {
    for (int i = 0; i < numToMove; i++)
    {
      MoveSlot(fromIndex, toIndex, toInventory);
    }
  }

}
