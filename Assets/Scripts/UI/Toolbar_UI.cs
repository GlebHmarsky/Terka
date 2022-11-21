using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Toolbar_UI : MonoBehaviour
{
  // FIXME: тут походу надо обращаться к самому inventory_UI за слотами, а то иначе 2 места получается
  [SerializeField] private List<Slot_UI> toolbarSlots = new List<Slot_UI>();

  private Slot_UI selectedSlot;

  void Start()
  {
    SelectSlot(0);
  }

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
    selectedSlot = toolbarSlots[index];
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