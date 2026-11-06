using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Locks and hides the cursor when the player clicks the game while in gameplay.
/// Browsers only allow pointer lock from a user gesture, so locking on focus or on
/// scene load (as Starter Assets does) fails in WebGL builds.
/// </summary>
public class CursorLockOnClick : MonoBehaviour
{
    const string PlayerActionMapName = "Player";

    [SerializeField] PlayerInput _playerInput;

    void Awake()
    {
        if (_playerInput == null)
        {
            _playerInput = FindFirstObjectByType<PlayerInput>();
        }
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked) return;
        if (!IsInGameplay()) return;

        Mouse mouse = Mouse.current;
        if (mouse != null && mouse.leftButton.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Gameplay means: not paused, not in the ending, and the player action map is active.
    bool IsInGameplay()
    {
        if (Time.timeScale <= 0.0f) return false;
        if (_playerInput == null || _playerInput.currentActionMap == null) return false;

        return _playerInput.currentActionMap.name == PlayerActionMapName;
    }
}
