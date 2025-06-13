using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneScript : MonoBehaviour
{
    // public Sprite[] sprites;
    // public float frameRate = 10f;
    // public float moveSpeed = 5f;
    // public float jumpForce = 7f;

    // private SpriteRenderer spriteRenderer;
    // private Rigidbody2D rb;
    // private int currentFrame = 0;
    // private float timer = 0f;
    // private bool isGrounded = false;

    // private float horizontalInput;

    // void Start()
    // {
    //     spriteRenderer = GetComponent<SpriteRenderer>();
    //     rb = GetComponent<Rigidbody2D>();
    //     rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    // }

    // void Update()
    // {
    //     HandleInput();
    //     HandleAnimation();
    // }

    // void FixedUpdate()
    // {
    //     MovePlayer();
    // }

    // void HandleInput()
    // {
    //     horizontalInput = Input.GetAxisRaw("Horizontal");
    //     if (Input.GetButtonDown("Jump") && isGrounded)
    //     {
    //         Debug.Log("Jump input detected and isGrounded is true");
    //         rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    //         isGrounded = false;
    //     }
    // }

    // void MovePlayer()
    // {
    //     Vector2 move = new Vector2(horizontalInput * moveSpeed * Time.fixedDeltaTime, 0f);
    //     rb.MovePosition(rb.position + move); // This respects collision
    // }

    // void HandleAnimation()
    // {
    //     if (horizontalInput != 0f)
    //     {
    //         timer += Time.deltaTime;
    //         if (timer >= 1f / frameRate)
    //         {
    //             currentFrame = (currentFrame + 1) % sprites.Length;
    //             spriteRenderer.sprite = sprites[currentFrame];
    //             timer = 0f;
    //         }

    //         spriteRenderer.flipX = horizontalInput < 0;
    //     }
    //     else
    //     {
    //         spriteRenderer.sprite = sprites[0];
    //         currentFrame = 0;
    //         timer = 0f;
    //     }
    // }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.contacts[0].normal.y > 0.5f)
    //     {
    //         isGrounded = true;
    //     }
    // }

    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     isGrounded = false;
    // }
}

