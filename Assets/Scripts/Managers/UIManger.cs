using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
  public Dictionary<InventoryName, Inventory_UI> inventoryUIByName = new Dictionary<InventoryName, Inventory_UI>();


  [Header("Inventory")]
  public GameObject inventoryPanel;
  public List<Inventory_UI> inventoryUIs;
  [Header("Chests")]
  public GameObject chestPanel;
  public GameObject chestUI;
  [Header("Shop")]
  public GameObject ShopPanel;
  public Shop_UI ShopUI;


  public List<GameObject> panels;

  public static Slot_UI draggedSlot;
  public static Image draggedIcon;
  public static bool dragSingle;

  private void Awake()
  {
    Initialize();
  }

  public static Inventory.Slot GetSlotFromDragged()
  {
    if (draggedSlot == null) return null;
    return draggedSlot.inventory.slots[draggedSlot.slotID];
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

  public void DropToWorld()
  {
    if (!draggedSlot) return;

    Inventory inventory = draggedSlot.inventory;
    if (inventory == null)
    {
      return;
    }
    Inventory.Slot slot = inventory.slots[draggedSlot.slotID];

    if (slot.itemData)
    {
      if (dragSingle)
      {
        GameManager.instance.playerManager.DropItem(slot.itemData);
        inventory.Remove(draggedSlot.slotID);
      }
      else
      {
        GameManager.instance.playerManager.DropItem(slot.itemData, slot.count);
        inventory.Remove(draggedSlot.slotID, slot.count);
      }
    }
  }

  public Inventory_UI GetInventoryUI(InventoryName inventoryName)
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
    bool isSomePanelActive = false;
    foreach (var panel in panels)
    {
      if (panel.activeSelf)
      {
        panel.SetActive(false);
        isSomePanelActive = true;
      }
    }

    if (!inventoryPanel || isSomePanelActive) return;
    inventoryPanel.SetActive(true);
  }

  public void OpenChestInventory(Chest chest)
  {
    Inventory_UI[] inventoryUIs = chestUI.GetComponents<Inventory_UI>();
    Inventory_UI inventoryForChestUI = null;
    foreach (var ui in inventoryUIs)
    {
      if (ui.inventoryName == InventoryName.None)
      {
        inventoryForChestUI = ui;
        break;
      }
    }
    if (!inventoryForChestUI) return;
    inventoryForChestUI.SetupInventory(chest.inventory);
    // TODO: think about: what if chest would destroy but invenotryUI still have a listner or other stuff 
    chestPanel.SetActive(true);
  }

  public void OpenShop(Shop shop)
  {
    ShopUI.shop = shop;
    ShopPanel.SetActive(true);
  }
}
