using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
  [SerializeField] private Tilemap interactableTilemap;
  [SerializeField] private Tile hiddenTile;

  /* на деле эта штука нужная чтобы просто скрыть тайлы за сценой. 
    Зачем? Чтобы мы видели ГДЕ можно взаимодействовать, а игрок понял это другим путём
    С этой же точки зрения нам потребуется один или два раза указать где тайлы должны быть
    А после можем же просто их спрятать вниз под сцену указав нужный уровень. 
    TODO:  Вопрос: так ли необходим данный manager? мне кажется и да и нет но вопрос открытый.
  */
  void Start()
  {
    foreach (var pos in getAllTilesPosition(interactableTilemap))
    {
      interactableTilemap.SetTile(pos, hiddenTile);
    }
  }

  public bool IsInteractable(Vector3Int position)
  {
    TileBase tile = interactableTilemap.GetTile(position);
    if (tile)
    {
      return true;
    }
    return false;
  }

  List<Vector3Int> getAllTilesPosition(Tilemap tilemap)
  {
    List<Vector3Int> tileWorldLocations = new List<Vector3Int>();
    foreach (var pos in tilemap.cellBounds.allPositionsWithin)
    {
      if (tilemap.HasTile(pos))
        tileWorldLocations.Add(pos);
    }

    return tileWorldLocations;
  }
}
