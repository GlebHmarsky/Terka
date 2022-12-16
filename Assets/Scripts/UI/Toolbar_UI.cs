using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Inventory_UI))]
public class Toolbar_UI : MonoBehaviour
{
  private Slot_UI selectedSlot;
  private Inventory_UI inventory_UI;

  void Start()
  {
    inventory_UI = GetComponent<Inventory_UI>();
    SelectSlot(0);
  }

  // FIXME: Переписать на эвенты
  // https://docs.unity3d.com/Manual/UIE-Keyboard-Events.html
  private void Update()
  {
    CheckAlphaNumericKeys();
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

  private void CheckAlphaNumericKeys()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      SelectSlot(0);
    }
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      SelectSlot(1);
    }
    if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      SelectSlot(2);
    }
    if (Input.GetKeyDown(KeyCode.Alpha4))
    {
      SelectSlot(3);
    }
    if (Input.GetKeyDown(KeyCode.Alpha5))
    {
      SelectSlot(4);
    }
    if (Input.GetKeyDown(KeyCode.Alpha6))
    {
      SelectSlot(5);
    }
    if (Input.GetKeyDown(KeyCode.Alpha7))
    {
      SelectSlot(6);
    }

  }

}
