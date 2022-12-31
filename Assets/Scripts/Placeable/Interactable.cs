using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
  public ScriptableObjectAction action;

  public void Call()
  {
    if (action)
    {
      action.PerformAction(this.gameObject);
    }
  }
}
