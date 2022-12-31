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
