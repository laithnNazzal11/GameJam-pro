using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private ScoreManagerScript scoreManagerScript;
    private SoundEffectsLayer soundEffects;

    private void Start()
    {
        scoreManagerScript = FindObjectOfType<ScoreManagerScript>();
        GameObject audioObj = GameObject.FindGameObjectWithTag("Audio");
        if (audioObj != null) {
            soundEffects = audioObj.GetComponent<SoundEffectsLayer>();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //scoreManagerScript.AddCoin();  // Add 1 to coin score
            if(!Input.GetKeyDown(KeyCode.G)){
                scoreManagerScript.coinCount++;  // Add 1 to coin score
            }
            
            // Play coin collection sound
            if (soundEffects != null && soundEffects.collectCoinSound != null) {
                soundEffects.PlaySFX(soundEffects.collectCoinSound);
            }
            
            Destroy(gameObject);  // Destroy the coin
        }
    }
}
