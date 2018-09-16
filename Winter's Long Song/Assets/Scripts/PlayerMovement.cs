using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    private float rayCastLength = 0.005f;
    private float width;
    private float height;
    private float jumpPressTime;
    private float maxJumpTime = 0.2f;
    private float yPos;
    public bool facingRight = true;
    public bool isJumping = false;
    public bool isGrounded = false;

	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<Collider2D>().bounds.extents.y + 0.2f;
    }
	
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        Vector2 vect = rb.velocity;
        rb.velocity = new Vector2(horizontalMove * moveSpeed, vect.y);
        if ((horizontalMove > 0 && !facingRight) || (horizontalMove < 0 && facingRight))
        {
            FlipPlayer();
        }
        float verticalMove = Input.GetAxis("Jump");
        Debug.Log(IsOnGround());
        if (IsOnGround() && !isJumping && verticalMove > 0f)
        {
            isJumping = true;
        }
        if (jumpPressTime > maxJumpTime)
        {
            verticalMove = 0f;
        }
        if (isJumping && (jumpPressTime < maxJumpTime))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        if (verticalMove >= 1f)
        {
            jumpPressTime += Time.deltaTime;
        } else
        {
            isJumping = false;
            jumpPressTime = 0;
        }
        if (GameObject.Find("Player").transform.position.y > -3.387 && !isGrounded && !isJumping)
        {
            verticalMove = 0f;
        }
        isGrounded = IsOnGround();
    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnBecameInvisible()
    {
        Debug.Log("Fell off the map");
        //Destroy(gameObject);
    }

    public bool IsOnGround()
    {
        bool groundCheck1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), -Vector2.up, rayCastLength);
        bool groundCheck2 = Physics2D.Raycast(new Vector2(transform.position.x + (width - 0.1f), transform.position.y - height), -Vector2.up, rayCastLength);
        bool groundCheck3 = Physics2D.Raycast(new Vector2(transform.position.x - (width - 0.1f), transform.position.y - height), -Vector2.up, rayCastLength);
        return (groundCheck1 || groundCheck2 || groundCheck3);
    }
}
