using UnityEngine;

public abstract class ScriptableItemAction : ScriptableObject
{
  /// <summary>
  /// Perform some action
  /// </summary>
  // ! FIXME: НУЖНО ИЗМЕНИТЬ АРГУМЕНТЫ ТАК,ЧТОБЫ ПРОКИДЫВАТЬ СЛОТ, А НЕ ЦЕЛУЮ ТОПКУ ИНВЕНТОРЯ
  public abstract void PerformAction(Vector2Int position);
}
