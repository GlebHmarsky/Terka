using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
  public GameObject inventoryPanel;
  public PlayerManager playerManager;
  [SerializeField] private Slot_UI slotPrefab;
  [SerializeField] private GameObject slotsParent;
  public List<Slot_UI> slots;

  [SerializeField] private Canvas canvas;

  private Slot_UI draggedSlot;
  private Image draggedIcon;

  private void Awake()
  {
    canvas = FindObjectOfType<Canvas>();
  }

  void Start()
  {
    /* TODO: Тут есть загвоздка которая мне не очень нравится
  Дело в том, что если инвентарь у игрока не успеет проинициализироваться 
  то тут он будет пустой. Это можно увидеть если Start заменить на Awake
  Тогда Инициализация  инвентаря так же будет на Awake и он не успеет сюда прийти
  проинициализированным. 
  
  TODO: Может сделать на эвент изменения размера инвентаря?
    */
    // InitiateInventoryUI();
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
      Slot_UI slotUI = Instantiate(slotPrefab, slotsParent.transform);
      slots.Add(slotUI);

      // Button button = slotUI.GetComponentInChildren<Button>();
      // if (button)
      // {
      //   // We must copy element 'cause closure (замыкание)
      //   int copy = i;
      //   button.onClick.AddListener(() => Remove(copy));
      // }
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
    for (int i = 0; i < slots.Count; i++)
    {
      if (playerInventory.slots[i].itemName != "")
      {
        slots[i].SetItem(playerInventory.slots[i]);
      }
      else
      {
        slots[i].SetEmpty();
      }
    }
  }

  public void Remove()
  {
    Item itemToDrop = GameManager.instance.itemManager.GetItemByName(playerManager.inventory.slots[draggedSlot.slotID].itemName);
    if (itemToDrop)
    {
      playerManager.DropItem(itemToDrop);
      playerManager.inventory.RemoveAll(draggedSlot.slotID);
      Refresh();
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
    draggedIcon.rectTransform.sizeDelta = new Vector2(50f, 50f);

    MoveToMousePosition(draggedIcon.gameObject);
    Debug.Log($"Begin drag: {draggedSlot.name}");
  }

  public void SlotDrag()
  {
    MoveToMousePosition(draggedIcon.gameObject);
    Debug.Log($"Dragging: {draggedSlot.name}");
  }

  public void SlotEndDrag()
  {
    Destroy(draggedIcon.gameObject);
    draggedIcon = null;
  }

  public void SlotDrop(Slot_UI slot)
  {
    Debug.Log($"Drop: {draggedSlot.name} on {slot.name}");
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

