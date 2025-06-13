using UnityEngine;

public class PlayerBottom : MonoBehaviour
{
    public Sprite[] sprites;
    public float frameRate = 10f;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    //

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private int currentFrame = 0;
    private float timer = 0f;
    private bool isGrounded = false;
    private float horizontalInput = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimation();
    }

    void HandleAnimation()
    {
        if (horizontalInput != 0f)
        {
            timer += Time.deltaTime;
            if (timer >= 1f / frameRate)
            {
                currentFrame = (currentFrame + 1) % sprites.Length;
                spriteRenderer.sprite = sprites[currentFrame];
                timer = 0f;
            }

            spriteRenderer.flipX = horizontalInput < 0;
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
            currentFrame = 0;
            timer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public void SetHorizontalInput(float input)
    {
        horizontalInput = input;
    }
}
