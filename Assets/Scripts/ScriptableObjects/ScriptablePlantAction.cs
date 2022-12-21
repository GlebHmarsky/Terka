using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptablePlantAction : ScriptableObject
{
  /// <summary>
  /// Perform some action for plants
  /// </summary>
  public abstract void PerformAction(Plant plant);
}
