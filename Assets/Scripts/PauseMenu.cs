using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    const string PlayerActionMapName = "Player";
    const string UIActionMapName = "UI";
    const float PausedTimeScale = 0.0f;
    const float RunningTimeScale = 1.0f;
    const int MainMenuSceneIndex = 0;

    public static bool gameIsPaused = false;

    [SerializeField] GameObject _pauseMenuUI;
    [SerializeField] PlayerInput _playerInput;

    void Awake()
    {
        if (_playerInput == null)
        {
            _playerInput = FindFirstObjectByType<PlayerInput>();
        }
    }

    /*
    public void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    */

    public void OnPause(InputValue value)
    {
        if (value.isPressed && !gameIsPaused)
        {
            PauseGame();
        }
    }

    public void OnResume(InputValue value)
    {
        if (value.isPressed && gameIsPaused)
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = PausedTimeScale;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        _playerInput.SwitchCurrentActionMap(UIActionMapName);
    }

    public void ResumeGame()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = RunningTimeScale;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerInput.SwitchCurrentActionMap(PlayerActionMapName);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(MainMenuSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
