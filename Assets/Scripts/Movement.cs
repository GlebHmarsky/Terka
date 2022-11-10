using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent Rigidbody2D]
public class Movement : MonoBehaviour
{

  public Rigidbody2D rb;
  public float movementSpeed = 12f;
  Vector2 movement;

  void Update()
  {
    movement.x = Input.GetAxis("Horizontal");
    movement.y = Input.GetAxis("Vertical");
  }

  void FixedUpdate()
  {
    rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
  }
}
