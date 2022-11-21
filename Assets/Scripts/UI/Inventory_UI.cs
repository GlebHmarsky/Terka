using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
  public GameObject inventoryPanel;
  public string inventoryName;
  public List<Slot_UI> slots;
  private bool dragSingle;

  [SerializeField] private Canvas canvas;

  private Slot_UI draggedSlot;
  private Image draggedIcon;

  private Inventory inventory;

  private void Awake()
  {
    canvas = FindObjectOfType<Canvas>();
  }

  void Start()
  {
    inventory = GameManager.instance.player.inventory.GetInventoryByName(inventoryName);

    /* TODO: Тут есть загвоздка которая мне не очень нравится
  Дело в том, что если инвентарь у игрока не успеет проинициализироваться 
  то тут он будет пустой. Это можно увидеть если Start заменить на Awake
  Тогда Инициализация  инвентаря так же будет на Awake и он не успеет сюда прийти
  проинициализированным. 
  
  TODO: Может сделать на эвент изменения размера инвентаря?
    */
    SetupSlots();
    Refresh();
    inventory.inventoryUpdate.AddListener(Refresh);
  }

  void Update()
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

  private void SetupSlots()
  {
    int inventoryLength = inventory.slots.Count;
    if (slots.Count != inventory.slots.Count)
    {
      return;
    }
    for (int i = 0; i < slots.Count; i++)
    {
      slots[i].slotID = i;
      slots[i].inventory = inventory;
    }
  }

  public void ToggleInventory()
  {
    if (!inventoryPanel) return;
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

  // FIXME: PLEEEEEASE! THats not good
  public void Refresh()
  {
    if (slots.Count != inventory.slots.Count) return;
    for (int i = 0; i < slots.Count; i++)
    {
      if (inventory.slots[i].itemName != "")
      {
        slots[i].SetItem(inventory.slots[i]);
      }
      else
      {
        slots[i].SetEmpty();
      }
    }
  }

  public void Remove()
  {
    Item itemToDrop = GameManager.instance.itemManager.GetItemByName(inventory.slots[draggedSlot.slotID].itemName);

    if (itemToDrop)
    {
      if (dragSingle)
      {
        GameManager.instance.player.DropItem(itemToDrop);
        inventory.Remove(draggedSlot.slotID);
      }
      else
      {
        GameManager.instance.player.DropItem(itemToDrop, inventory.slots[draggedSlot.slotID].count);
        inventory.RemoveAll(draggedSlot.slotID);
      }
    }
    draggedSlot = null;
  }

  public void SlotBeginDrag(Slot_UI slot)
  {
    draggedSlot = slot;

    draggedIcon = Instantiate(draggedSlot.itemIcon, canvas.transform);

    Destroy(draggedIcon.GetComponent<AspectRatioFitter>());
    draggedIcon.raycastTarget = false;
    draggedIcon.SetNativeSize();
    draggedIcon.rectTransform.anchorMin = new Vector2(0, 0);
    draggedIcon.rectTransform.sizeDelta = new Vector2(70f, 70f);
    draggedIcon.color = new Color(1, 1, 1, 0.5f);

    MoveToMousePosition(draggedIcon.gameObject);
  }

  public void SlotDrag()
  {
    MoveToMousePosition(draggedIcon.gameObject);
  }

  public void SlotEndDrag()
  {
    Destroy(draggedIcon.gameObject);
    draggedIcon = null;
  }

  public void SlotDrop(Slot_UI slot)
  {
    Debug.Log($"Drop: {draggedSlot.slotID}, {slot.slotID}");
    draggedSlot.inventory.MoveSlot(draggedSlot.slotID, slot.slotID);
  }

  private void MoveToMousePosition(GameObject toMove)
  {
    if (canvas)
    {
      Vector2 position;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
      toMove.transform.position = canvas.transform.TransformPoint(position);
    }
  }

}

