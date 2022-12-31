using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory_UI : MonoBehaviour
{
  public InventoryName inventoryName;
  public List<Slot_UI> slots;

  [SerializeField] private Canvas canvas;

  private Inventory inventory;

  private void Awake()
  {
    canvas = FindObjectOfType<Canvas>();
  }

  void Start()
  {
    SetupInitialSlots();

    if (inventoryName == InventoryName.None) return;

    SetupInventory(GameManager.instance.player.inventory.GetInventoryByName(inventoryName));
  }

  public void SetupInventory(Inventory newInventory)
  {
    if (newInventory == null) return;
    this.inventory = newInventory;
    SetupSlotsInventory();
    Refresh();
    inventory.inventoryUpdate += Refresh;
  }

  private void SetupSlotsInventory()
  {
    int inventoryLength = inventory.slots.Count;
    if (slots.Count != inventory.slots.Count)
    {
      return;
    }

    for (int i = 0; i < slots.Count; i++)
    {
      Slot_UI slot = slots[i];
      slot.inventory = inventory;
    }
  }

  public void SetupInitialSlots()
  {
    for (int i = 0; i < slots.Count; i++)
    {
      Slot_UI slot = slots[i];
      slot.slotID = i;

      EventTrigger trigger = slot.GetComponent<EventTrigger>();

      EventTrigger.Entry slotBeginDrag = new EventTrigger.Entry();
      slotBeginDrag.eventID = EventTriggerType.BeginDrag;
      slotBeginDrag.callback.AddListener((data) => SlotBeginDrag(slot));

      EventTrigger.Entry slotDrag = new EventTrigger.Entry();
      slotDrag.eventID = EventTriggerType.Drag;
      slotDrag.callback.AddListener((data) => SlotDrag());

      EventTrigger.Entry slotEndDrag = new EventTrigger.Entry();
      slotEndDrag.eventID = EventTriggerType.EndDrag;
      slotEndDrag.callback.AddListener((data) => SlotEndDrag());

      EventTrigger.Entry slotDrop = new EventTrigger.Entry();
      slotDrop.eventID = EventTriggerType.Drop;
      slotDrop.callback.AddListener((data) => SlotDrop(slot));

      /* по поводу trigger.triggers.Clear();
      Отчасти это стремная вещь. Поясню. Каждый раз когда мы открываем инвентарь - происходит ициализация слотов
      Но они уже частично инициализированы на самом то деле. 
      Всё что им по факту нужно поменять - так это инвентарь 
      а этот Clear упрощает жизнь но в очень странном контексте. Я переживаю за 4 листнера выше - как бы они не скопились
      и не забили стек. 
      поэтому

      PS: трабл пофикшен, оставлю комментарий для потомков надеюсь они это когда-нибудь прочтут и зададут вопрос "чё тут было?"
      PSS: коммент можно убрать в любой момент когда он тут надоест
       */
      trigger.triggers.Clear();
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

