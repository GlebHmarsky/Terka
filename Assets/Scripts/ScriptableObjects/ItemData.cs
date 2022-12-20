using UnityEngine;

[CreateAssetMenu(menuName = "Item Data")]
public class ItemData : ScriptableObject
{
  public string itemName = "Item Name";
  public Sprite icon;
  public ScriptableAction Action;
}
