using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
  private Rigidbody rb;
  private Vector3 movement;
  [SerializeField] private float movementSpeed;


  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    //We can use just GetAxis, but player move like on a butter with more slide effect
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.z = Input.GetAxisRaw("Vertical");

  }

  void FixedUpdate()
  {
    // movement.normalized - for diagonal movement will have the same speed as well as horz. or vert.
    rb.MovePosition(rb.position + (transform.TransformDirection(movement.normalized) * movementSpeed * Time.fixedDeltaTime));
  }
}
