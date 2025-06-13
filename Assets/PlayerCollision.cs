using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject gameOverPanel; // Drag your GameOver UI Panel in Inspector

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Hide Game Over UI at start
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            HealthManager.health--;

            if (HealthManager.health <= 0)
            {
                // Show Game Over UI instead of loading scene
                if (gameOverPanel != null)
                {
                    gameOverPanel.SetActive(true);
                    Time.timeScale = 0f; // Pause the game
                }

                gameObject.SetActive(false); // Disable player
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
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
