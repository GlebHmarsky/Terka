using UnityEngine;

[RequireComponent(typeof(Inventory_UI))]
public class Toolbar_UI : MonoBehaviour
{
  private Slot_UI selectedSlot;
  private Inventory_UI inventory_UI;
  public InventoryManager inventoryManager;
  void Start()
  {
    inventory_UI = GetComponent<Inventory_UI>();

    // TODO: погуглить как бы перенести это в сам IM чтобы хронология Start была верной.
    inventoryManager.changeSelectedSlot += SelectSlot;
    inventoryManager.SelectSlot(0);
  }

  public void SelectSlot(int index)
  {
    if (selectedSlot)
    {
      selectedSlot.SetHighlight(false);
    }
    selectedSlot = inventory_UI.slots[index];
    selectedSlot.SetHighlight(true);
  }


}
