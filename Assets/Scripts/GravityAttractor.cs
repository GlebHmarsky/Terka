using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
  public float gravity = -10f;

  public void Attract(GravityBody body)
  {
    Transform bodyTransform = body.transform;
    Vector3 targetDir = (bodyTransform.position - transform.position).normalized;
    Vector3 bodyUp = bodyTransform.up;

    bodyTransform.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * bodyTransform.rotation;
    body.rb.AddForce(targetDir * gravity);
  }

}
