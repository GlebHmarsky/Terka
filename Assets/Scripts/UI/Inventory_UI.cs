using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory_UI : MonoBehaviour
{
  public string inventoryName;
  public List<Slot_UI> slots;

  [SerializeField] private Canvas canvas;

  private Inventory inventory;

  private void Awake()
  {
    canvas = FindObjectOfType<Canvas>();
  }

  void Start()
  {
    if (inventoryName == "") return;

    // FIXME: очень надо чтобы тут было enum :(
    SetupInventory(GameManager.instance.player.inventory.GetInventoryByName(inventoryName));
  }

  public void SetupInventory(Inventory newInventory)
  {
    if (newInventory == null) return;
    this.inventory = newInventory;
    SetupSlots();
    Refresh();
    inventory.inventoryUpdate.AddListener(Refresh);
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

      // TODO: Обязательно заняться проверкой что эта интересная операция не сжирает все запасы памяти при инициализациизации
      EventTrigger trigger = slots[i].GetComponent<EventTrigger>();

      EventTrigger.Entry slotBeginDrag = new EventTrigger.Entry();
      slotBeginDrag.eventID = EventTriggerType.BeginDrag;
      slotBeginDrag.callback.AddListener((data) => SlotBeginDrag(slots[i]));

      EventTrigger.Entry slotDrag = new EventTrigger.Entry();
      slotDrag.eventID = EventTriggerType.Drag;
      slotDrag.callback.AddListener((data) => SlotDrag());

      EventTrigger.Entry slotEndDrag = new EventTrigger.Entry();
      slotEndDrag.eventID = EventTriggerType.Drag;
      slotEndDrag.callback.AddListener((data) => SlotEndDrag());

      EventTrigger.Entry slotDrop = new EventTrigger.Entry();
      slotDrop.eventID = EventTriggerType.Drag;
      slotDrop.callback.AddListener((data) => SlotDrop(slots[i]));

      trigger.triggers.Add(slotBeginDrag);
      trigger.triggers.Add(slotDrag);
      trigger.triggers.Add(slotEndDrag);
      trigger.triggers.Add(slotDrop);
    }
  }

  public void Refresh()
  {
    if (slots.Count != inventory.slots.Count) return;
    for (int i = 0; i < slots.Count; i++)
    {
      if (inventory.slots[i].itemData != null)
      {
        slots[i].SetItem(inventory.slots[i]);
      }
      else
      {
        slots[i].SetEmpty();
      }
    }
  }

  public void SlotBeginDrag(Slot_UI slot)
  {
    UIManger.draggedSlot = slot;

    UIManger.draggedIcon = Instantiate(UIManger.draggedSlot.itemIcon, canvas.transform);

    Destroy(UIManger.draggedIcon.GetComponent<AspectRatioFitter>());
    UIManger.draggedIcon.raycastTarget = false;
    UIManger.draggedIcon.SetNativeSize();
    UIManger.draggedIcon.rectTransform.anchorMin = new Vector2(0, 0);
    UIManger.draggedIcon.rectTransform.sizeDelta = new Vector2(70f, 70f);
    UIManger.draggedIcon.color = new Color(1, 1, 1, 0.5f);

    MoveToMousePosition(UIManger.draggedIcon.gameObject);
  }

  public void SlotDrag()
  {
    MoveToMousePosition(UIManger.draggedIcon.gameObject);
  }

  public void SlotEndDrag()
  {
    Destroy(UIManger.draggedIcon.gameObject);
    UIManger.draggedIcon = null;
  }

  public void SlotDrop(Slot_UI slot)
  {
    if (!UIManger.draggedSlot) return;

    if (UIManger.dragSingle)
    {
      UIManger.draggedSlot.inventory.MoveSlot(UIManger.draggedSlot.slotID, slot.slotID, slot.inventory);
    }
    else
    {
      UIManger.draggedSlot.inventory.MoveSlot(UIManger.draggedSlot.slotID, slot.slotID, slot.inventory, UIManger.draggedSlot.inventory.slots[UIManger.draggedSlot.slotID].count);
    }
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

