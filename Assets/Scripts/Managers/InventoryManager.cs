using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
  public Dictionary<string, Inventory> inventoryByName = new Dictionary<string, Inventory>();

  [Header("Backpack")]
  public Inventory backpack;
  public int backpackSlotCount;

  [Header("Toolbar")]
  public Inventory toolbar;
  public int toolbarSlotCount;
  private int selectedSlot = 0;


  // [Header("Events")]
  [HideInInspector] public UnityEvent<int> changeSelectedSlot;

  private void Awake()
  {
    backpack = new Inventory(backpackSlotCount);
    toolbar = new Inventory(toolbarSlotCount);

    inventoryByName.Add("Backpack", backpack);
    inventoryByName.Add("Toolbar", toolbar);

    changeSelectedSlot = new UnityEvent<int>();
  }

  private void Update()
  {
    // FIXME: Переписать на эвенты
    // https://docs.unity3d.com/Manual/UIE-Keyboard-Events.html
    CheckAlphaNumericKeys();
  }

  public void Add(string inventoryName, ItemData itemData)
  {
    Inventory inventory = GetInventoryByName(inventoryName);
    if (inventory != null)
    {
      inventory.Add(itemData);
    }
  }


  public Inventory GetInventoryByName(string inventoryName)
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
    changeSelectedSlot.Invoke(index);
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
