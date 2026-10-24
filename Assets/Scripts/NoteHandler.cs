using UnityEngine;
using UnityEngine.InputSystem;

public class NoteHandler : MonoBehaviour
{
    const string PlayerActionMapName = "Player";
    const string UIActionMapName = "UI";
    const float PausedTimeScale = 0.0f;
    const float RunningTimeScale = 1.0f;


    [SerializeField] PlayerInput _playerInput;
    [SerializeField] GameObject _closeNoteText;

    GameObject _currentNote;
    bool _readingNote;

    void Awake()
    {
        if (_playerInput == null)
        {
            _playerInput = FindFirstObjectByType<PlayerInput>();
        }
    }

    public void OpenNote(GameObject note)
    {
        _currentNote = note;
        _currentNote.SetActive(true);
        _readingNote = true;
        _playerInput.SwitchCurrentActionMap(UIActionMapName);
        _closeNoteText.SetActive(true);
        Time.timeScale = PausedTimeScale;
    }

    public void OnCloseNote(InputValue value)
    {
        if(value.isPressed && _readingNote)
        {
            _readingNote = false;
            _currentNote.SetActive(false);
            _currentNote = null;
            _playerInput.SwitchCurrentActionMap(PlayerActionMapName);
            _closeNoteText.SetActive(false);
            Time.timeScale = RunningTimeScale;
        }
    }
}
