using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        Debug.Log("Start button clicked!");
        // Add your scene loading logic here
        SceneManager.LoadScene("SampleScene");
    }
}