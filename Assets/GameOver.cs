using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] private string sceneName;
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneName);
    }
}
