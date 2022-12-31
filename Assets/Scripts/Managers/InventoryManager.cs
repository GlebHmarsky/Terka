using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemCountPair
{
  public ItemData itemData;
  public int count = 1;
}

public enum InventoryName
{
  None,
  Backpack,
  Toolbar
}

public class InventoryManager : MonoBehaviour
{
  public Dictionary<InventoryName, Inventory> inventoryByName = new Dictionary<InventoryName, Inventory>();

  [Header("Backpack")]
  public Inventory backpack;
  public int backpackSlotCount;

  [Header("Toolbar")]
  public Inventory toolbar;
  public int toolbarSlotCount;
  private int selectedSlot = 0;

  [Header("Default items")]
  public List<ItemCountPair> defaultItems;

  public event Action<int> changeSelectedSlot;

  private void Awake()
  {
    backpack = new Inventory(backpackSlotCount);
    toolbar = new Inventory(toolbarSlotCount);

    inventoryByName.Add(InventoryName.Backpack, backpack);
    inventoryByName.Add(InventoryName.Toolbar, toolbar);
  }
  private void Start()
  {
    foreach (var itemPair in defaultItems)
    {
      Add(InventoryName.Toolbar, itemPair.itemData, itemPair.count);
    }
  }

  private void Update()
  {
    // FIXME: Переписать на эвенты
    /* боюсь эвентами не отделаемся и нужная новая херня под названием Unity NEW event system 
    Оставил комментарий в ноушене на эту тему */
    // https://docs.unity3d.com/Manual/UIE-Keyboard-Events.html
    CheckAlphaNumericKeys();
  }

  /// <summary>
  /// Add items to selected inventory
  /// </summary>
  /// <returns>True if item successfully added. False otherwise (no slots)</returns>
  public bool Add(InventoryName inventoryName, ItemData itemData)
  {
    Inventory inventory = GetInventoryByName(inventoryName);
    if (inventory != null)
    {
      return inventory.Add(itemData);
    }
    return false;
  }

  /// <summary>
  /// Add items to selected inventory with count
  /// </summary>
  /// <returns>True if item successfully added. False otherwise (no slots)</returns>
  public int Add(InventoryName inventoryName, ItemData itemData, int count)
  {
    int i;
    for (i = 0; i < count; i++)
    {
      if (!Add(inventoryName, itemData))
      {
        break;
      }
    }
    return count - i;
  }

  public Inventory GetInventoryByName(InventoryName inventoryName)
  {
    if (inventoryByName.ContainsKey(inventoryName))
    {
      return inventoryByName[inventoryName];
    }
    return null;
  }

  public Inventory.Slot GetSelectedSlot()
  {
    return toolbar.slots[selectedSlot];
  }

  public void RemoveSelectedItem()
  {
    toolbar.Remove(selectedSlot);
  }

  public void SelectSlot(int index)
  {
    selectedSlot = index;
    changeSelectedSlot(index);
  }

  private void CheckAlphaNumericKeys()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      SelectSlot(0);
    }
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      SelectSlot(1);
    }
    if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      SelectSlot(2);
    }
    if (Input.GetKeyDown(KeyCode.Alpha4))
    {
      SelectSlot(3);
    }
    if (Input.GetKeyDown(KeyCode.Alpha5))
    {
      SelectSlot(4);
    }
    if (Input.GetKeyDown(KeyCode.Alpha6))
    {
      SelectSlot(5);
    }
    if (Input.GetKeyDown(KeyCode.Alpha7))
    {
      SelectSlot(6);
    }
  }
}
