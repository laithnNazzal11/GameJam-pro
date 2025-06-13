using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private SoundEffectsLayer soundEffects;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if(HealthManager.health <= 0){
                // PlayerManager.isGameOver = true;
                // AudioManager.instance.Play("GameOver");
                SceneManager.LoadScene(sceneName);
                gameObject.SetActive(false);
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
        // Cache the animator reference
        animator = GetComponent<Animator>();
        
        // Find the sound effects layer
        GameObject audioObj = GameObject.FindGameObjectWithTag("Audio");
        if (audioObj != null) {
            soundEffects = audioObj.GetComponent<SoundEffectsLayer>();
        }
    }

    IEnumerator GetHurt(){ 
        Physics2D.IgnoreLayerCollision(6,8);

        // Only try to use the animator if it exists
        if (animator != null)
        {
            animator.SetLayerWeight(1, 1);
        }

        yield return new WaitForSeconds(3);

        // Only try to use the animator if it exists
        if (animator != null)
        {
            animator.SetLayerWeight(1, 0);
        }

        Physics2D.IgnoreLayerCollision(6,8, false);
    }
}
