using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
  public GravityAttractor planet;
  [HideInInspector] public Rigidbody rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
    rb.useGravity = false;
    rb.constraints = RigidbodyConstraints.FreezeRotation;
  }

  void FixedUpdate()
  {
    planet.Attract(this);
  }
}
