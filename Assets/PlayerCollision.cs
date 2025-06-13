using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if(HealthManager.health <=0){
                // PlayerManager.isGameOver = true;
                // AudioManager.instance.Play("GameOver");
                SceneManager.LoadScene(sceneName);
                gameObject.SetActive(false);
            }else{
                StartCoroutine(GetHurt());
            }
        }
    }
    private Animator animator;

    private void Start()
    {
        // Cache the animator reference
        animator = GetComponent<Animator>();
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
