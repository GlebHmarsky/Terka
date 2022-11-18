using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
  public GameObject inventoryPanel;
  public PlayerManager playerManager;

  public List<Slot_UI> slots;

  private void Start()
  {
    Refresh();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Tab))
    {
      ToggleInventory();
    }
  }

  public void ToggleInventory()
  {

    if (!inventoryPanel.activeSelf)
    {
      inventoryPanel.SetActive(true);
      Refresh();
    }
    else
    {
      inventoryPanel.SetActive(false);
    }
  }

  public void Refresh()
  {
    Inventory pmInv = playerManager.inventory;
    if (slots.Count == pmInv.slots.Count)
    {
      for (int i = 0; i < slots.Count; i++)
      {
        if (pmInv.slots[i].type != CollectableType.NONE)
        {
          slots[i].SetItem(pmInv.slots[i]);
        }
        else
        {
          slots[i].SetEmpty();
        }
      }
    }
  }
}
