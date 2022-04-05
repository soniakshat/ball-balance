using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Play");
    }
    public void QuitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
