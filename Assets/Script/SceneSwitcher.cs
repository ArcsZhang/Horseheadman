using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Load Main Menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Load Tutorial scene
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // Load Start Game scene
    public void LoadStartGame()
    {
        SceneManager.LoadScene("StartGame");
    }

    // Exit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
