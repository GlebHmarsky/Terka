using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
  public Image itemIcon;
  public TextMeshProUGUI quantityText;
  public AspectRatioFitter aspectRatioFitter;
  // FIXME: Hide me
  public int slotID;

  [SerializeField] private GameObject highlight;

  public void SetItem(Inventory.Slot slot)
  {
    itemIcon.sprite = slot.icon;
    itemIcon.color = new Color(1, 1, 1, 1);
    quantityText.text = slot.count.ToString();
    aspectRatioFitter.aspectRatio = slot.icon.bounds.size.x / slot.icon.bounds.size.y; //For correct sprite ratio drawing
  }
  public void SetEmpty()
  {
    itemIcon.sprite = null;
    itemIcon.color = new Color(1, 1, 1, 0);
    quantityText.text = "";
  }

  public void SetHighlight(bool isOn)
  {
    highlight.SetActive(isOn);
  }
}
