using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        // Add your scene loading logic here
        SceneManager.LoadScene("SampleScene");
    }
}