using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
  private Rigidbody2D rigidbody2d;
  private Vector2 movement;
  [SerializeField] private float movementSpeed;
  [SerializeField] private Animator animator;


  private void Awake()
  {
    rigidbody2d = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    //We can use just GetAxis, but player move like on a butter with more slide effect
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    animator.SetFloat("Horizontal", movement.x);
    animator.SetFloat("Vertical", movement.y);
    animator.SetFloat("Speed", movement.sqrMagnitude);
  }

  void FixedUpdate()
  {
    // movement.normalized - for diagonal movement will have the same speed as well as horz. or vert.
    rigidbody2d.MovePosition(rigidbody2d.position + (movement.normalized * movementSpeed * Time.fixedDeltaTime));
  }
}
