using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{

  [SerializeField] private Tilemap interactableTilemap;
  [SerializeField] private Tile hiddenTile;


  void Start()
  {
    foreach (var pos in getAllTilesPosition(interactableTilemap))
    {
      interactableTilemap.SetTile(pos, hiddenTile);
    }
  }


  // TODO: utils stuff, should move somewhere else
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
