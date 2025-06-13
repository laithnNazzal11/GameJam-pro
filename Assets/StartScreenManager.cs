using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown difficultyDropdown;

    private void Start()
    {
        // Initialize dropdown options if not set in editor
        if (difficultyDropdown != null)
        {
            difficultyDropdown.ClearOptions();
            difficultyDropdown.AddOptions(new System.Collections.Generic.List<string> { "Easy", "Medium", "Hard" });
        }
    }

    public void StartGame()
    {
        if (difficultyDropdown == null)
        {
            Debug.LogError("Difficulty Dropdown is not assigned!");
            return;
        }

        string selectedDifficulty = difficultyDropdown.options[difficultyDropdown.value].text;
        Debug.Log("Starting game with difficulty: " + selectedDifficulty); // Add this for debugging

        switch (selectedDifficulty)
        {
            case "Easy":
                SceneManager.LoadScene("SampleScene");
                break;
            case "Medium":
                SceneManager.LoadScene("SampleScene");
                break;
            case "Hard":
                SceneManager.LoadScene("SampleScene");
                break;
            default:
                Debug.LogWarning("Unknown difficulty level, loading default scene");
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}