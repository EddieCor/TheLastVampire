using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Plays the ending: waits for the final animation, plays the ending audio, then shows the end screen.
/// Hook <see cref="BeginEnding"/> to the final interactable's "On Interacted" event.
/// </summary>
public class EndGameSequence : MonoBehaviour
{
    const string UIActionMapName = "UI";
    const float PausedTimeScale = 0.0f;
    const float RunningTimeScale = 1.0f;
    const float DefaultAnimationDuration = 2.0f;
    const float DefaultNoAudioDelay = 1.0f;
    const int MainMenuSceneIndex = 0;

    [SerializeField] GameObject _endScreen;
    [SerializeField] PlayerInput _playerInput;

    [Header("Timing")]
    [Tooltip("Seconds to wait for the final animation before the audio plays.")]
    [SerializeField] float _animationDuration = DefaultAnimationDuration;

    [Header("Audio (optional)")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _endClip;
    [Tooltip("Seconds to wait before the end screen when no clip is assigned.")]
    [SerializeField] float _noAudioDelay = DefaultNoAudioDelay;

    bool _hasStarted;

    void Awake()
    {
        if (_playerInput == null)
        {
            _playerInput = FindFirstObjectByType<PlayerInput>();
        }
    }

    /// <summary>Starts the ending sequence. Safe to call more than once.</summary>
    public void BeginEnding()
    {
        if (_hasStarted)
        {
            return;
        }

        _hasStarted = true;
        StartCoroutine(EndingRoutine());
    }

    /// <summary>Loads the main menu scene. Intended for a UI button.</summary>
    public void LoadMainMenu()
    {
        Time.timeScale = RunningTimeScale;
        AudioListener.pause = false;
        SceneManager.LoadScene(MainMenuSceneIndex);
    }

    /// <summary>Quits the application. Intended for a UI button.</summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator EndingRoutine()
    {
        // Take movement and look away from the player while the ending plays.
        _playerInput.SwitchCurrentActionMap(UIActionMapName);

        yield return new WaitForSeconds(_animationDuration);

        float audioDuration = _noAudioDelay;

        if (_audioSource != null && _endClip != null)
        {
            _audioSource.PlayOneShot(_endClip);
            audioDuration = _endClip.length;
        }

        yield return new WaitForSeconds(audioDuration);

        _endScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = PausedTimeScale;
    }
}
