using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    const int GameSceneIndex = 1;

    public void PlayGame()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}