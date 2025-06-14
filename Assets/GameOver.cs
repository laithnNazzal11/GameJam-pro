using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private SoundEffectsLayer soundEffects;
    [SerializeField] private GameObject gameOverPanel; 
      
    void Start()
    {
        soundEffects = FindObjectOfType<SoundEffectsLayer>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (soundEffects != null)
        {
            soundEffects.PlaySFX(soundEffects.winSound);
        }
        if (gameOverPanel != null)
        {
            HealthManager.health = 0;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }
}
