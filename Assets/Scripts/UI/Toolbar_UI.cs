using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Toolbar_UI : MonoBehaviour
{
  [SerializeField] private Slot_UI slotPrefab;
  [SerializeField] private GameObject slotsParent;
  [SerializeField] private List<Slot_UI> toolbarSlots = new List<Slot_UI>();

  private Slot_UI selectedSlot;

  void Start()
  {
    InitiateToolbarUI(7);
    SelectSlot(0);
  }

  private void Update()
  {
    CheckAlphaNumericKeys();
  }

  private void InitiateToolbarUI(int toolbarSize)
  {
    int inventoryLength = toolbarSize;
    for (int i = 0; i < inventoryLength; i++)
    {
      Slot_UI slotUI = Instantiate(slotPrefab, slotsParent.transform);
      toolbarSlots.Add(slotUI);

      Transform keyTextTransform = slotUI.transform.GetChild(2);
      if (keyTextTransform)
      {
        TextMeshPro text = keyTextTransform.GetComponent<TextMeshPro>();
        if (text)
        {
          text.text = $"{i + 1}";
        }
      }
    }
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
