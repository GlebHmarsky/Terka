using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
  public ScriptableObjectAction action;

  public void Call()
  {
    Debug.Log("CALL HAS BEEN CALLED!");
    if (action)
    {
      action.PerformAction(this.gameObject);
    }
  }
}
