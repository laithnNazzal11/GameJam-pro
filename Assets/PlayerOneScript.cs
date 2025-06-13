using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneScript : MonoBehaviour
{
    public Sprite[] sprites;       // Animation frames
    public float frameRate = 10f;  // Frames per second
    public float moveSpeed = 5f;   // Movement speed
    // public float jumpForce = 5f;   // Jump force
    // public float jumpDelay = 0.5f; // Delay between jumps
    // public float jumpCooldown = 0.5f; // Cooldown between jumps
    // public float jumpTimer = 0f; // Timer for jump cooldown
    // public float jumpTimerDelay = 0.5f; // Delay for jump cooldown
    // public float jumpTimerDelay = 0.5f; // Delay for jump cooldown

    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float timer = 0f;

    private Vector2 input;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
        HandleAnimation();
    }

    void HandleInput()
    {
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            input = gamepad.leftStick.ReadValue();
        }
        else
        {
            var keyboard = Keyboard.current;
            float x = 0, y = 0;
            if (keyboard.aKey.isPressed) x -= 1;
            if (keyboard.dKey.isPressed) x += 1;
            if (keyboard.wKey.isPressed) y += 1;
            if (keyboard.sKey.isPressed) y -= 1;
            input = new Vector2(x, y);
        }
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(input.x, input.y, 0f).normalized;
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    void HandleAnimation()
    {
        if (input != Vector2.zero)
        {
            timer += Time.deltaTime;
            if (timer >= 1f / frameRate)
            {
                currentFrame = (currentFrame + 1) % sprites.Length;
                spriteRenderer.sprite = sprites[currentFrame];
                timer = 0f;
            }

            // Flip sprite based on direction
            if (input.x != 0)
                spriteRenderer.flipX = input.x < 0;
        }
        else
        {
            // Idle frame (first sprite)
            spriteRenderer.sprite = sprites[0];
            currentFrame = 0;
            timer = 0f;
        }
    }
}

