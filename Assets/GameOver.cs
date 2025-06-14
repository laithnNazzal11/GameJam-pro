using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private SoundEffectsLayer soundEffects;
    
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
        SceneManager.LoadScene(sceneName);
    }
}
