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
  [HideInInspector] public int slotID;
  public Inventory inventory;
  /*Идея того, чтобы не хранить тут инвентарь так как мне это не нравится. 
  Суть такова: мы можем подвязаться на эвенты вновь и сделать слушателя в инвентаре на эвенты из UI 
  тк все действия происходят именно там. 
  добавить события что случилось перемещение какого-то слота в другое место
  и Инвокать его на соответствующее событие

  так мы уберём потребность в том чтобы инвентарь был тут
  это удобно, но мне кажется совершенно не правильным подходом. 

  PS: наверное двигать предмет между двумя инвернторями станет проблематичнее, так как мы не будем
  знать знать хотя бы 1 из 2 инвенторей. 
  Крч идея крах, мне лень её фиксить

  PSS коммент имхо можно удалить, оставляю для молодых

   */

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
