using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject gameOverPanel; // Drag your GameOver UI Panel in Inspector

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
}
