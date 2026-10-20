using System.Collections;
using UnityEngine;

/// <summary>
/// One-shot dialogue zone. When the player enters, it plays a voice line and shows the subtitle
/// text, then deactivates itself once the voice line has finished.
/// Which objects can reach this trigger is controlled by the physics layer matrix.
/// </summary>
[RequireComponent(typeof(Collider))]
public class DialogueTriggerZone : MonoBehaviour
{
    const float DefaultTextOnlyDuration = 3.0f;

    [SerializeField] GameObject _dialogueText;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _voiceLine;
    [Tooltip("How long the text stays visible when no voice line is assigned.")]
    [SerializeField] float _textOnlyDuration = DefaultTextOnlyDuration;

    bool _hasTriggered;

    void OnTriggerEnter(Collider other)
    {
        if (_hasTriggered)
        {
            return;
        }

        _hasTriggered = true;
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        float duration = _textOnlyDuration;

        if (_audioSource != null && _voiceLine != null)
        {
            _audioSource.PlayOneShot(_voiceLine);
            duration = _voiceLine.length;
        }

        if (_dialogueText != null)
        {
            _dialogueText.SetActive(true);
        }

        // Scaled time keeps the subtitle in sync with the voice line while paused
        // (the pause menu freezes timeScale and pauses the AudioListener).
        yield return new WaitForSeconds(duration);

        if (_dialogueText != null)
        {
            _dialogueText.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
