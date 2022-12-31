using UnityEngine;

public class MouseSelect : MonoBehaviour
{
  public Vector2Int position;
  public Vector3 position3d;
  public GameObject highlightTile;
  void Update()
  {
    OnMouseMovement();
  }

  void OnMouseMovement()
  {
    // int x = Mathf.FloorToInt(transform.position.x);
    // int y = Mathf.FloorToInt(transform.position.y);
    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    position = new Vector2Int(Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.y));
    position3d = (Vector3)(Vector2)position + (new Vector3(0.5f, 0.5f, 0));

    highlightTile.transform.position = position3d;
  }
}
