using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject gameOverPanel; 
      
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameOverPanel != null)
        {
            HealthManager.health = 0;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }
}
