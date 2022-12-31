using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
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
      return itemData == this.itemData && this.count < maxAllowed;
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
    public int AddItem(ItemData itemData, int count)
    {
      this.itemData = itemData;
      icon = itemData.icon;
      int restCount = maxAllowed - this.count - count;
      restCount = restCount > 0 ? 0 : restCount;
      this.count += count - restCount;
      return restCount;
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

  public event Action inventoryUpdate;
  public List<Slot> slots = new List<Slot>();

  public Inventory(int numSlots)
  {
    for (int i = 0; i < numSlots; i++)
    {
      slots.Add(new Slot());
    }
  }

  /// <summary>
  /// Add item to inventory with searching same ItemData type
  /// </summary>
  /// <param name="itemData"></param>
  /// <returns>True if item successfully added. False otherwise (no slots)</returns>
  public bool Add(ItemData itemData)
  {
    foreach (var slot in slots)
    {
      if (!slot.itemData) continue;
      if (slot.itemData == itemData && slot.CanBeAdded(itemData))
      {
        slot.AddItem(itemData);
        inventoryUpdate();
        return true;
      }
    }
    foreach (var slot in slots)
    {
      if (!slot.itemData)
      {
        slot.AddItem(itemData);
        inventoryUpdate();
        return true;
      }
    }
    return false;
  }

  /// <summary>
  /// Add item to inventory with searching same ItemData type
  /// </summary>
  /// <returns>Count of items that could not fit in inventory</returns>
  public int Add(ItemData itemData, int count)
  {
    int restCount = 0;
    foreach (var slot in slots)
    {
      if (!slot.itemData) continue;
      if (slot.CanBeAdded(itemData))
      {
        restCount = slot.AddItem(itemData, count);
        count = restCount;
        if (restCount == 0)
        {
          inventoryUpdate();
          return 0;
        }
      }
    }
    foreach (var slot in slots)
    {
      if (!slot.itemData)
      {
        restCount = slot.AddItem(itemData, count);
        count = restCount;
        if (restCount == 0)
        {
          inventoryUpdate();
          return 0;
        }
      }
    }
    return restCount;
  }

  public void Remove(int index)
  {
    slots[index].RemoveItem();
    inventoryUpdate();
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
      this.inventoryUpdate();

      // Invoke event if there second inventory that we moving to slot
      if (toInventory != this)
      {
        toInventory.inventoryUpdate();
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
