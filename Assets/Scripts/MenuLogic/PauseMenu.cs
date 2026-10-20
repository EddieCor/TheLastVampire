using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    const string PlayerActionMapName = "Player";
    const string UIActionMapName = "UI";
    const float PausedTimeScale = 0.0f;
    const float RunningTimeScale = 1.0f;
    const int MainMenuSceneIndex = 0;

    //public static bool GameIsPaused = false;
    [SerializeField] GameObject _pauseMenuUI;
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] GameObject _interactionText;

    bool _gameIsPaused = false;
    bool _wasInteractionTextActive;

    void Awake()
    {
        if (_playerInput == null)
        {
            _playerInput = FindFirstObjectByType<PlayerInput>();
        }
    }

    public void OnPause(InputValue value)
    {
        if (value.isPressed && !_gameIsPaused)
        {
            PauseGame();
        }
    }

    public void OnResume(InputValue value)
    {
        if (value.isPressed && _gameIsPaused)
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = PausedTimeScale;
        _gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        _playerInput.SwitchCurrentActionMap(UIActionMapName);
        AudioListener.pause = true;

        if(_interactionText.activeInHierarchy)
        {
            _interactionText.SetActive(false);
            _wasInteractionTextActive = true;
        }
    }

    public void ResumeGame()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = RunningTimeScale;
        _gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerInput.SwitchCurrentActionMap(PlayerActionMapName);
        AudioListener.pause = false;

        if (_wasInteractionTextActive)
        {
            _interactionText.SetActive(true);
            _wasInteractionTextActive = false;
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        SceneManager.LoadScene(MainMenuSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
