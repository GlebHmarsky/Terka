using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
  public ItemData data;
  public int count = 1;
  
  [HideInInspector] public Rigidbody2D rb2d;

  private void Awake()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }
}
