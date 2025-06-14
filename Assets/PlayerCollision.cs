using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject gameOverPanel; // Drag your GameOver UI Panel in Inspector
    [SerializeField] private GameObject ChooseOne; // Drag your GameOver UI Panel in Inspector

    private SoundEffectsLayer soundEffects;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if(HealthManager.health <= 0){
                // PlayerManager.isGameOver = true;
                // AudioManager.instance.Play("GameOver");
                //SceneManager.LoadScene(sceneName);
                if (gameOverPanel != null)
                {
                    gameOverPanel.SetActive(true);
                    Time.timeScale = 0f; // Pause the game
                }

                gameObject.SetActive(false); // Disable player
            } else {
                // Play damage sound only when health decreases but is greater than zero
                if (soundEffects != null && soundEffects.damageSound != null) {
                    soundEffects.PlaySFX(soundEffects.damageSound);
                }
                
                StartCoroutine(GetHurt());
            }
        }
    }
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        // Find the sound effects layer
        GameObject audioObj = GameObject.FindGameObjectWithTag("Audio");
        if (audioObj != null) {
            soundEffects = audioObj.GetComponent<SoundEffectsLayer>();
        }
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Hide Game Over UI at start

        if (ChooseOne != null)
            ChooseOne.SetActive(false);
    }


    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);

        if (animator != null)
        {
            animator.SetLayerWeight(1, 1);
        }

        yield return new WaitForSeconds(3);

        if (animator != null)
        {
            animator.SetLayerWeight(1, 0);
        }

        Physics2D.IgnoreLayerCollision(6, 8, false);
    }

    // Called from the UI Button
    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void DestroyPlayerOne()
    {
        GameObject playerOne = GameObject.Find("PlayerTop");
        if (playerOne != null)
        {
            Destroy(playerOne);

            // Find the camera and set its follow target to PlayerBottom
            CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
            GameObject playerTwo = GameObject.Find("PlayerBottom");
            if (camFollow != null && playerTwo != null)
            {
                camFollow.target = playerTwo.transform;
            }

            ChooseOne.SetActive(false);
            Time.timeScale = 1f; // Resume the game
        }
    }

    public void DestroyPlayerTwo()
    {
        GameObject playerTwo = GameObject.Find("PlayerBottom");
        if (playerTwo != null)
        {
            Destroy(playerTwo);
            // Set references to null so Update() knows it's gone
            var manager = FindObjectOfType<PlayerPairManager>();
            if (manager != null)
            {
                manager.PlayerBottom = null;
                // Use reflection or make these fields public if needed
                var rbBottomField = typeof(PlayerPairManager).GetField("rbBottom", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (rbBottomField != null) rbBottomField.SetValue(manager, null);
                var playerBottomScriptField = typeof(PlayerPairManager).GetField("playerBottomScript", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (playerBottomScriptField != null) playerBottomScriptField.SetValue(manager, null);
                var groundCheckBottomField = typeof(PlayerPairManager).GetField("groundCheckBottom", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (groundCheckBottomField != null) groundCheckBottomField.SetValue(manager, null);
            }
            ChooseOne.SetActive(false);
            Time.timeScale = 1f; // Resume the game
        }
    }
}
