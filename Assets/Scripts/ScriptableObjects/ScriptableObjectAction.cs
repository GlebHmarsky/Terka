using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableObjectAction : ScriptableObject
{
  /// <summary>
  /// Perform some action with object
  /// </summary>
  public abstract void PerformAction(GameObject gameObject);
}
