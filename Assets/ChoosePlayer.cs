using UnityEngine;

public class ChoosePlayer : MonoBehaviour
{
    [SerializeField] private GameObject ChooseOne; // Drag your ChooseOne UI Panel in Inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string sceneName;
    private SoundEffectsLayer soundEffects;
    [SerializeField] private GameObject gameOverPanel; 
      
    void Start()
    {
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Only trigger if the colliding object is the player
        if (other.CompareTag("Player") && ChooseOne != null)
        {
            ChooseOne.SetActive(true);
            Time.timeScale = 0f; 
            
        }
    }


}
