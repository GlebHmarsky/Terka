using UnityEngine;

public class ItemManager : MonoBehaviour
{
  // public List<ItemData> itemDataList;
  public Item itemPrefab;

  public Item CreateItem(ItemData itemData, Vector2 spawnLocation, Quaternion rotation)
  {
    Item item = Instantiate(itemPrefab, spawnLocation, rotation);
    item.data = itemData;
    SpriteRenderer spriteRenderer = item.GetComponentInChildren<SpriteRenderer>();
    spriteRenderer.sprite = itemData.icon;

    return item;
  }

}
