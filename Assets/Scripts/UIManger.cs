using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
  public Dictionary<string, Inventory_UI> inventoryUIByName = new Dictionary<string, Inventory_UI>();

  public List<Inventory_UI> inventoryUIs;

  public GameObject inventoryPanel;


  public static string draggedFromInventory;
  public static Slot_UI draggedSlot;
  public static Image draggedIcon;
  public static bool dragSingle;

  private void Awake()
  {
    Initialize();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Tab))
    {
      ToggleInventory();
    }

    if (Input.GetKey(KeyCode.LeftShift))
    {
      dragSingle = true;
    }
    else
    {
      dragSingle = false;
    }
  }

  void Initialize()
  {
    foreach (Inventory_UI ui in inventoryUIs)
    {
      if (!inventoryUIByName.ContainsKey(ui.inventoryName))
      {
        inventoryUIByName.Add(ui.inventoryName, ui);
      }
    }
  }

  public Inventory_UI GetInventoryUI(string inventoryName)
  {
    if (inventoryUIByName.ContainsKey(inventoryName))
    {
      return inventoryUIByName[inventoryName];
    }

    Debug.LogWarning($"There is not inventory ui for {inventoryName}");
    return null;
  }

  public void ToggleInventory()
  {
    if (!inventoryPanel) return;
    if (!inventoryPanel.activeSelf)
    {
      inventoryPanel.SetActive(true);
    }
    else
    {
      inventoryPanel.SetActive(false);
    }
  }

  public void DropToWorld()
  {
    Inventory inventory = GameManager.instance.player.inventory.GetInventoryByName(GetInventoryUI(draggedFromInventory).inventoryName);
    if (inventory == null)
    {
      return;
    }
    Inventory.Slot slot = inventory.slots[draggedSlot.slotID];
    Item itemToDrop = GameManager.instance.itemManager.GetItemByName(slot.itemName);
    if (itemToDrop)
    {
      if (dragSingle)
      {
        GameManager.instance.player.DropItem(itemToDrop);
        inventory.Remove(draggedSlot.slotID);
      }
      else
      {
        GameManager.instance.player.DropItem(itemToDrop, slot.count);
        inventory.Remove(draggedSlot.slotID, slot.count);
      }
    }
  }
}
