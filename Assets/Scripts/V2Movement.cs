using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public string up;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;
    private bool facingRight = true;
//---------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input for movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3 (0, 0, 0);


        //if (input.GetButtonDown("Jump") && isGrounded)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
       //     isGrounded = false;
        //}

        if (Input.GetKey(up))
        {
            move = new Vector3 (0, Time.deltaTime * 20f, 0);
        }

        this.transform.Translate(move); 




        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

//---------------------------------------------------------------------------------------------------------------------------------------

        // Jump input
        //if (isGrounded && Input.GetButtonDown("Jump"))
        //{
           // rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //}

        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight;


        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        
    }
}