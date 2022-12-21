using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
  public string itemName = "Item Name";
  public Sprite icon;
  public ScriptableItemAction Action;
  public PlantData plantSeed;
}
