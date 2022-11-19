using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
  public GameObject inventoryPanel;
  public PlayerManager playerManager;
  [SerializeField] private GameObject slotPrefab;
  [SerializeField] private GameObject slotsParent;
  public List<Slot_UI> slots;

  // public Button btn;
  // btn.onClick.AddListener(() => Remove(0));

  void Start()
  {
    /* TODO: Тут есть загвоздка которая мне не очень нравится
  Дело в том, что если инвентарь у игрока не успеет проинициализироваться 
  то тут он будет пустой. Это можно увидеть если Start заменить на Awake
  Тогда Инициализация  инвентаря так же будет на Awake и он не успеет сюда прийти
  проинициализированным. 
  
  TODO: Может сделать на эвент изменения размера инвентаря?
    */
    InitiateInventoryUI();
    Refresh();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Tab))
    {
      ToggleInventory();
    }
  }

  private void InitiateInventoryUI()
  {
    Inventory playerInventory = playerManager.inventory;
    int inventoryLength = playerInventory.slots.Count;
    for (int i = 0; i < inventoryLength; i++)
    {
      GameObject slotUI = Instantiate(slotPrefab, slotsParent.transform);
      Slot_UI slot_UI = slotUI.GetComponent<Slot_UI>();
      if (slot_UI)
      {
        slots.Add(slot_UI);
      }
      Button button = slotUI.GetComponentInChildren<Button>();
      if (button)
      {
        // We must copy element 'cause closure (замыкание)
        int copy = i;
        button.onClick.AddListener(() => Remove(copy));
      }
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
    Inventory playerInventory = playerManager.inventory;
    if (slots.Count == playerInventory.slots.Count)
    {
      for (int i = 0; i < slots.Count; i++)
      {
        if (playerInventory.slots[i].type != CollectableType.NONE)
        {
          slots[i].SetItem(playerInventory.slots[i]);
        }
        else
        {
          slots[i].SetEmpty();
        }
      }
    }
  }

  public void Remove(int slotID)
  {
    playerManager.inventory.Remove(slotID);
    Refresh();
  }
}
