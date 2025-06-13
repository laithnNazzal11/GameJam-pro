using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private ScoreManagerScript scoreManagerScript;
     

    private void Start()
    {
        scoreManagerScript = FindObjectOfType<ScoreManagerScript>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //scoreManagerScript.AddCoin();  // Add 1 to coin score
            if(!Input.GetKeyDown(KeyCode.G)){
            scoreManagerScript.coinCount ++;  // Add 1 to coin score
            }
            ;  // Add 1 to coin score

            Destroy(gameObject);                    // Destroy the coin
        }
    }
}
