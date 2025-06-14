using UnityEngine;

public class PlayerPairManager : MonoBehaviour
{
    public GameObject PlayerTop;
    public GameObject PlayerBottom;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheckTop;
    public Transform groundCheckBottom;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rbTop;
    private Rigidbody2D rbBottom;
    private PlayerTop playerTopScript;
    private PlayerBottom playerBottomScript;
    
    SoundEffectsLayer soundEffects;

    void Awake(){
        GameObject audioObj = GameObject.FindGameObjectWithTag("Audio");
        if (audioObj != null) {
            soundEffects = audioObj.GetComponent<SoundEffectsLayer>();
        }
      
    }

    void Start()
    {
        // Get and check Rigidbody2D components
        rbTop = PlayerTop.GetComponent<Rigidbody2D>();


        rbBottom = PlayerBottom.GetComponent<Rigidbody2D>();


        // Get and check player scripts
        playerTopScript = PlayerTop.GetComponent<PlayerTop>();


        playerBottomScript = PlayerBottom.GetComponent<PlayerBottom>();


        // Create ground check transforms if they don't exist
        if (groundCheckTop == null)
        {
            GameObject checkTop = new GameObject("GroundCheckTop");
            checkTop.transform.parent = PlayerTop.transform;
            checkTop.transform.localPosition = new Vector3(0, -0.5f, 0);
            groundCheckTop = checkTop.transform;
        }

        if (groundCheckBottom == null)
        {
            GameObject checkBottom = new GameObject("GroundCheckBottom");
            checkBottom.transform.parent = PlayerBottom.transform;
            checkBottom.transform.localPosition = new Vector3(0, -0.5f, 0);
            groundCheckBottom = checkBottom.transform;
        }

    }

    void Update()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;

        // Set horizontal input for animation
        if (playerTopScript != null)
            playerTopScript.SetHorizontalInput(moveInput);
        if (playerBottomScript != null)
            playerBottomScript.SetHorizontalInput(moveInput);

        // Apply horizontal movement
        if (rbTop != null)
            rbTop.linearVelocity = new Vector2(moveInput * moveSpeed, rbTop.linearVelocity.y);
        if (rbBottom != null)
            rbBottom.linearVelocity = new Vector2(moveInput * moveSpeed, rbBottom.linearVelocity.y);

        // Check for jump
        bool isTopGrounded = groundCheckTop != null && Physics2D.OverlapCircle(groundCheckTop.position, groundCheckRadius, groundLayer);
        bool isBottomGrounded = groundCheckBottom != null && rbBottom != null && Physics2D.OverlapCircle(groundCheckBottom.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isTopGrounded && rbTop != null)
            {
                rbTop.linearVelocity = new Vector2(rbTop.linearVelocity.x, jumpForce);
                if (soundEffects != null)
                    soundEffects.PlaySFX(soundEffects.jumpSound);
            }

            if (isBottomGrounded && rbBottom != null)
            {
                rbBottom.linearVelocity = new Vector2(rbBottom.linearVelocity.x, -jumpForce);
                if (soundEffects != null)
                    soundEffects.PlaySFX(soundEffects.jumpSound);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw ground check circles in editor
        if (groundCheckTop != null)
            Gizmos.DrawWireSphere(groundCheckTop.position, groundCheckRadius);
        if (groundCheckBottom != null)
            Gizmos.DrawWireSphere(groundCheckBottom.position, groundCheckRadius);
    }
}
