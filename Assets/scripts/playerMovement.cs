using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movementInput;
    public float moveSpeed;

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.MovePosition( rb.position + movementInput * Time.fixedDeltaTime * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
    