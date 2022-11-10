using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
  private Rigidbody2D rigidbody2d;
  private Vector2 movement;
  [SerializeField] private float movementSpeed;

  private void Awake()
  {
    rigidbody2d = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    movement.x = Input.GetAxis("Horizontal");
    movement.y = Input.GetAxis("Vertical");
  }

  void FixedUpdate()
  {
    rigidbody2d.MovePosition(rigidbody2d.position + movement * movementSpeed * Time.fixedDeltaTime);
  }
}
