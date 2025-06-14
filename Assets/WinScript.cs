using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; 
      
    void OnTriggerEnter2D(Collider2D other)
    {
      SceneManager.LoadScene("StartScreen");
    }
}
