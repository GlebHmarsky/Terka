using UnityEngine;
using UnityEngine.EventSystems;

public class Shop_UI : MonoBehaviour
{
  public Shop shop;
  public GameObject panelForSelling;

  void Start()
  {
    SetupSellPanel();
  }

  private void SetupSellPanel()
  {
    EventTrigger trigger = panelForSelling.GetComponent<EventTrigger>();

    EventTrigger.Entry slotDrag = new EventTrigger.Entry();
    slotDrag.eventID = EventTriggerType.Drop;
    slotDrag.callback.AddListener((data) => SellItem());

    trigger.triggers.Clear();
    trigger.triggers.Add(slotDrag);
  }

  private void SellItem()
  {
    shop.SellItem();
  }
}
