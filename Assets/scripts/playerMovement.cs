using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool doubleJump = true;
    public float castDistance;
    public LayerMask groundLayer;
    public Vector2 boxSize;
    private float x;

    void Update()
    {

        // jump
        if (playerState.alive)
        {
            if (Input.GetButtonDown("Jump") && doubleJump)
            {
                if (!IsGrounded()) doubleJump = false;
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            // player side movements
            x = Input.GetAxisRaw("Horizontal");

            if (x != 0)
            {
                transform.Translate(new Vector3(x, 0, 0) * moveSpeed * Time.fixedDeltaTime);
            }

            // swap directions
            if (x > 0) transform.localScale = Vector3.one;
            else if (x < 0) transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && playerState.alive)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.rotation = 0;

            if (IsGrounded())
            {
                doubleJump = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }


    // checks if the object is on the ground
    public bool IsGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }; return false;
    }
}