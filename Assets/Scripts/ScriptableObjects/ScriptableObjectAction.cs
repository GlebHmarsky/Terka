using UnityEngine;

public abstract class ScriptableObjectAction : ScriptableObject
{
  /// <summary>
  /// Perform some action with object
  /// </summary>
  public abstract void PerformAction(GameObject gameObject);
}
